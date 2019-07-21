using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.Services;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Attributes;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Areas.Gamification.Controllers
{
    [Area("gamification")]
    [Route("gamification/ranking")]
    public class RankingController : SecureBaseController
    {
        private readonly IGamificationAppService gamificationAppService;
        private readonly IProfileAppService profileAppService;

        public RankingController(IGamificationAppService gamificationAppService, IProfileAppService profileAppService)
        {
            this.gamificationAppService = gamificationAppService;
            this.profileAppService = profileAppService;
        }


        [Authorize]
        public IActionResult Index()
        {
            var serviceResult = gamificationAppService.GetAll();

            var objs = serviceResult.Value.ToList();

            foreach (var obj in objs)
            {
                obj.ProfileImageUrl = UrlFormatter.ProfileImage(obj.UserId);
                obj.CoverImageUrl = UrlFormatter.ProfileCoverImage(obj.UserId, obj.Id);

                var profile = this.profileAppService.GetByUserId(obj.UserId, ProfileType.Personal);
                if (profile != null)
                {
                    obj.Name = profile.Name;
                }
            }

            return View(objs);
        }
    }
}