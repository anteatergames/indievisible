using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
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