using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Attributes;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Controllers
{
    public class ProfileController : SecureBaseController
    {
        private readonly IProfileAppService profileAppService;
        private readonly INotificationAppService notificationAppService;
        private readonly IGamificationAppService gamificationAppService;

        public ProfileController(IProfileAppService profileAppService
            , INotificationAppService notificationAppService
            , IGamificationAppService gamificationAppService) : base()
        {
            this.profileAppService = profileAppService;
            this.notificationAppService = notificationAppService;
            this.gamificationAppService = gamificationAppService;
        }

        [HttpGet]
        [Route("profile/{id:guid}")]
        public async Task<IActionResult> Details(Guid id, Guid notificationclicked)
        {
            ProfileViewModel vm = profileAppService.GetByUserId(CurrentUserId, id, ProfileType.Personal);
            if (vm == null)
            {
                ProfileViewModel profile = profileAppService.GenerateNewOne(ProfileType.Personal);

                ApplicationUser user = await UserManager.FindByIdAsync(id.ToString());

                if (user != null)
                {
                    profile.UserId = id;
                    profileAppService.Save(CurrentUserId, profile);
                }
                else
                {
                    TempData["Message"] = SharedLocalizer["User not found!"].Value;
                    return RedirectToAction("Index", "Home");
                }

                vm = profile;
            }

            gamificationAppService.FillProfileGamificationDetails(CurrentUserId, ref vm);

            if (CurrentUserId != Guid.Empty)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());
                bool userIsAdmin = await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());
                vm.Permissions.IsAdmin = userIsAdmin;
                vm.Permissions.CanEdit = vm.UserId == CurrentUserId;
                vm.Permissions.CanFollow = vm.UserId != CurrentUserId;
                vm.Permissions.CanConnect = vm.UserId != CurrentUserId;


                if (notificationclicked != Guid.Empty)
                {
                    notificationAppService.MarkAsRead(notificationclicked);
                }
            }

            return View(vm);
        }

        [Route("profile/edit/{userId:guid}")]
        public IActionResult Edit(Guid userId)
        {
            ProfileViewModel vm = profileAppService.GetByUserId(userId, ProfileType.Personal, true);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Save(ProfileViewModel vm, IFormFile avatar)
        {
            try
            {
                profileAppService.Save(CurrentUserId, vm);

                string url = Url.Action("Details", "Profile", new { area = string.Empty, id = vm.UserId.ToString() });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }
    }
}