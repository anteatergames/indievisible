using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class FeedViewComponent : ViewComponent
    {
        private UserManager<ApplicationUser> _userManager;
        public UserManager<ApplicationUser> UserManager => _userManager ?? (_userManager = HttpContext?.RequestServices.GetService<UserManager<ApplicationUser>>());

        private readonly IUserPreferencesAppService _userPreferencesAppService;

        public Guid CurrentUserId { get; set; }

        private readonly IUserContentAppService _userContentAppService;

        public FeedViewComponent(IHttpContextAccessor httpContextAccessor, IUserContentAppService userContentAppService, IUserPreferencesAppService userPreferencesAppService)
        {
            _userContentAppService = userContentAppService;
            _userPreferencesAppService = userPreferencesAppService;

            string id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                CurrentUserId = new Guid(id);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(int count, Guid? gameId, Guid? userId, Guid? oldestId, DateTime? oldestDate)
        {
            UserPreferencesViewModel preferences = _userPreferencesAppService.GetByUserId(CurrentUserId);

            List<SupportedLanguage> languages = preferences.Languages;

            List<UserContentListItemViewModel> model = _userContentAppService.GetActivityFeed(CurrentUserId, count, gameId, userId, languages, oldestId, oldestDate).ToList();

            ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());
            bool userIsAdmin = user != null && await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());

            foreach (var item in model)
            {

                item.Content = ContentHelper.FormatContentToShow(item.Content);

                item.Permissions.CanDelete = item.UserId == CurrentUserId || userIsAdmin;
            }

            if (model.Any())
            {
                var oldest = model.OrderByDescending(x => x.CreateDate).Last();

                ViewData["OldestPostGuid"] = oldest.Id;
                ViewData["OldestPostDate"] = oldest.CreateDate.ToString("o");
            }

            ViewData["IsMorePosts"] = oldestId.HasValue;

            ViewData["UserId"] = userId;

            return await Task.Run(() => View(model));
        }
    }
}
