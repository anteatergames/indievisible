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

            var vm = new ActivityFeedRequestViewModel
            {
                CurrentUserId = CurrentUserId,
                Count = count,
                GameId = gameId,
                UserId = userId,
                Languages = preferences.Languages,
                OldestId = oldestId,
                OldestDate = oldestDate,
                ArticlesOnly = articlesOnly
            };

            List<UserContentListItemViewModel> model = _userContentAppService.GetActivityFeed(vm).ToList();

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
            string[] teamData = item.Content.Split('|');
            string id = teamData[0];
            string name = teamData[1];
            string motto = teamData[2];
            string memberCount = teamData[3];

            string postTemplate = ContentHelper.FormatUrlContentToShow(item.UserContentType);
            Microsoft.Extensions.Localization.LocalizedString translatedText = SharedLocalizer["A new team has been created with {0} members.", memberCount];
            item.Content = String.Format(postTemplate, translatedText, name, motto);
            item.Url = Url.Action("Details", "Team", new { teamId = id });
        }
    }
}
