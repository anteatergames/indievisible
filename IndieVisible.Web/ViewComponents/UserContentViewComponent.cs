using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class UserContentViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserPreferencesAppService _userPreferencesAppService;

        public Guid UserId { get; set; }

        private readonly IUserContentAppService _userContentAppService;

        public UserContentViewComponent(IHttpContextAccessor httpContextAccessor, IUserContentAppService userContentAppService, IUserPreferencesAppService userPreferencesAppService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userContentAppService = userContentAppService;
            _userPreferencesAppService = userPreferencesAppService;

            string id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                UserId = new Guid(id);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(int count, Guid gameId, Guid userId)
        {
            UserPreferencesViewModel preferences = _userPreferencesAppService.GetByUserId(UserId);

            List<SupportedLanguage> languages = preferences.Languages;

            List<UserContentListItemViewModel> model = _userContentAppService.GetActivityFeed(UserId, count, gameId, userId, languages).ToList();

            return View(model);
        }
    }
}
