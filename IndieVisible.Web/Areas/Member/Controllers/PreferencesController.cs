using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Attributes;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Member.Controllers.Base;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Areas.Member.Controllers
{
    public class PreferencesController : MemberBaseController
    {
        private readonly IUserPreferencesAppService _appService;

        public PreferencesController(IUserPreferencesAppService appService)
        {
            _appService = appService;
        }

        public IActionResult Edit()
        {
            UserPreferencesViewModel vm = _appService.GetByUserId(CurrentUserId);

            return View("CreateEdit", vm);
        }

        [HttpPost]
        public IActionResult Save(UserPreferencesViewModel vm)
        {
            try
            {
                vm.UserId = CurrentUserId;

                _appService.Save(vm);

                var selectedCulture = vm.UiLanguage.GetAttributeOfType<UiInfoAttribute>().Culture;

                SetLanguage(selectedCulture);


                return Json(new OperationResultVo(true));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        public void SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), IsEssential = true }
            );
        }
    }
}