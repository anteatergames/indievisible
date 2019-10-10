using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Web.Helpers;
using IndieVisible.Web.ViewComponents.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Web.Extensions;

namespace IndieVisible.Web.ViewComponents
{
    public class FeedViewComponent : BaseViewComponent
    {
        private UserManager<ApplicationUser> _userManager;
        public UserManager<ApplicationUser> UserManager => _userManager ?? (_userManager = HttpContext?.RequestServices.GetService<UserManager<ApplicationUser>>());

        private readonly IUserPreferencesAppService _userPreferencesAppService;

        private readonly IUserContentAppService _userContentAppService;

        public FeedViewComponent(IHttpContextAccessor httpContextAccessor, IUserContentAppService userContentAppService, IUserPreferencesAppService userPreferencesAppService) : base(httpContextAccessor)
        {
            _userContentAppService = userContentAppService;
            _userPreferencesAppService = userPreferencesAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count, Guid? gameId, Guid? userId, Guid? oldestId, DateTime? oldestDate, bool? articlesOnly)
        {
            UserPreferencesViewModel preferences = _userPreferencesAppService.GetByUserId(CurrentUserId);

            List<SupportedLanguage> languages = preferences.Languages;

            List<UserContentListItemViewModel> model = _userContentAppService.GetActivityFeed(CurrentUserId, count, gameId, userId, languages, oldestId, oldestDate, articlesOnly).ToList();

            ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());
            bool userIsAdmin = user != null && await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());

            foreach (UserContentListItemViewModel item in model)
            {
                if (item.UserContentType == UserContentType.TeamCreation)
                {
                    FormatTeamCreationPost(item);
                }
                else
                {
                    item.Content = ContentHelper.FormatContentToShow(item.Content);
                }

                item.Permissions.CanEdit = !item.HasPoll && (item.UserId == CurrentUserId || userIsAdmin);

                item.Permissions.CanDelete = item.UserId == CurrentUserId || userIsAdmin;
            }

            if (model.Any())
            {
                UserContentListItemViewModel oldest = model.OrderByDescending(x => x.CreateDate).Last();

                ViewData["OldestPostGuid"] = oldest.Id;
                ViewData["OldestPostDate"] = oldest.CreateDate.ToString("o");
            }

            ViewData["IsMorePosts"] = oldestId.HasValue;

            ViewData["UserId"] = userId;

            return await Task.Run(() => View(model));
        }

        private void FormatTeamCreationPost(UserContentListItemViewModel item)
        {
            var teamData = item.Content.Split('|', StringSplitOptions.RemoveEmptyEntries);
            var id = teamData[0];
            var name = teamData[1];
            var motto = teamData[2];
            var memberCount = teamData[3];

            var postTemplate = ContentHelper.FormatUrlContentToShow(item.UserContentType);
            var translatedText = SharedLocalizer["A new team has been created with {0} members.", memberCount];
            item.Content = String.Format(postTemplate, translatedText, name, motto);
            item.Url = Url.Action("Details", "Team", new { teamId = id });
        }
    }
}
