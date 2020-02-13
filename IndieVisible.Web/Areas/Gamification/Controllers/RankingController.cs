using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
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

        [Route("help")]
        public IActionResult Help()
        {
            OperationResultListVo<GamificationLevelViewModel> objs = gamificationAppService.GetAllLevels();

            return View(objs.Value);
        }

        public IActionResult Index()
        {
            OperationResultListVo<RankingViewModel> serviceResult = gamificationAppService.GetAll();

            List<RankingViewModel> objs = serviceResult.Value.ToList();

            foreach (RankingViewModel obj in objs)
            {
                Application.ViewModels.User.ProfileViewModel profile = profileAppService.GetUserProfileWithCache(obj.UserId);

                if (profile != null)
                {
                    obj.Name = profile.Name;
                    obj.ProfileImageUrl = UrlFormatter.ProfileImage(obj.UserId);
                    obj.CoverImageUrl = UrlFormatter.ProfileCoverImage(obj.UserId, profile.Id, profile.LastUpdateDate, profile.HasCoverImage);
                }
            }

            return View(objs);
        }
    }
}