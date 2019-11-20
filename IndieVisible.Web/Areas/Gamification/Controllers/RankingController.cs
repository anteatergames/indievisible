using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
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
            Domain.ValueObjects.OperationResultListVo<Application.ViewModels.Gamification.GamificationLevelViewModel> objs = gamificationAppService.GetAllLevels();

            return View(objs.Value);
        }

        public IActionResult Index()
        {
            Domain.ValueObjects.OperationResultListVo<Application.ViewModels.Gamification.RankingViewModel> serviceResult = gamificationAppService.GetAll();

            System.Collections.Generic.List<Application.ViewModels.Gamification.RankingViewModel> objs = serviceResult.Value.ToList();

            foreach (Application.ViewModels.Gamification.RankingViewModel obj in objs)
            {

                var profile = profileAppService.GetBasicDataByUserId(obj.UserId);

                if (profile != null)
                {
                    obj.Name = profile.Name;
                    obj.ProfileImageUrl = UrlFormatter.ProfileImage(obj.UserId);
                    obj.CoverImageUrl = UrlFormatter.ProfileCoverImage(obj.UserId, obj.Id, profile.HasCoverImage);
                }
            }

            return View(objs);
        }
    }
}