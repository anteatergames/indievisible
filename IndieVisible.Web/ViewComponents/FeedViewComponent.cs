﻿using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class FeedViewComponent : ViewComponent
    {
        private readonly IUserPreferencesAppService _userPreferencesAppService;

        public Guid UserId { get; set; }

        private readonly IUserContentAppService _userContentAppService;

        public FeedViewComponent(IHttpContextAccessor httpContextAccessor, IUserContentAppService userContentAppService, IUserPreferencesAppService userPreferencesAppService)
        {
            _userContentAppService = userContentAppService;
            _userPreferencesAppService = userPreferencesAppService;

            string id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                UserId = new Guid(id);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(int count, Guid? gameId, Guid? userId, Guid? oldestId, DateTime? oldestDate)
        {
            UserPreferencesViewModel preferences = _userPreferencesAppService.GetByUserId(UserId);

            List<SupportedLanguage> languages = preferences.Languages;

            List<UserContentListItemViewModel> model = _userContentAppService.GetActivityFeed(UserId, count, gameId, userId, languages, oldestId, oldestDate).ToList();

            foreach (var item in model)
            {
                item.Content = ContentHelper.FormatContentToShow(item.Content);
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