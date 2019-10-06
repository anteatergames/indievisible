using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Domain.Core.Attributes;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Areas.Gamification.Controllers
{
    [Area("gamification")]
    [Route("gamification/userbadge")]
    public class UserBadgeController : SecureBaseController
    {
        private readonly IUserBadgeAppService userBadgeAppService;

        public UserBadgeController(IUserBadgeAppService userBadgeAppService)
        {
            this.userBadgeAppService = userBadgeAppService;
        }

        [Route("help")]
        public IActionResult Help()
        {
            Dictionary<string, UiInfoAttribute> badges = SetBadgeList();

            ViewData["Badges"] = badges;

            return View();
        }

        [Route("list/{id}")]
        public IActionResult ListByUser(Guid id)
        {
            OperationResultListVo<UserBadgeViewModel> badges = userBadgeAppService.GetByUserId(id);

            return View("_List", badges.Value);
        }
        private static Dictionary<string, UiInfoAttribute> SetBadgeList()
        {
            List<KeyValuePair<string, UiInfoAttribute>> list = new List<KeyValuePair<string, UiInfoAttribute>>();

            IEnumerable<BadgeType> badges = Enum.GetValues(typeof(BadgeType)).Cast<BadgeType>();

            badges.ToList().ForEach(x =>
            {
                var uiInfo = x.GetAttributeOfType<UiInfoAttribute>();

                list.Add(new KeyValuePair<string, UiInfoAttribute>(x.ToString(), uiInfo));
            });

            Dictionary<string, UiInfoAttribute> dict = list.OrderBy(x => x.Value.Order).ToDictionary(x => x.Key, x => x.Value);

            return dict;
        }
    }
}