using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            ProfileViewModel vm = profileAppService.GetByUserId(this.CurrentUserId, id, ProfileType.Personal);
            if (vm == null)
            {
                ProfileViewModel profile = profileAppService.GenerateNewOne(ProfileType.Personal);
                profile.UserId = id;
                profileAppService.Save(this.CurrentUserId, profile);

                vm = profile;
            }

            this.SetImages(vm);

            this.FormatExternalNetworkUrls(vm);

            this.gamificationAppService.FillProfileGamificationDetails(this.CurrentUserId, ref vm);

            if (this.CurrentUserId != Guid.Empty)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());
                bool userIsAdmin = await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());
                vm.Permissions.IsAdmin = userIsAdmin;
                vm.Permissions.CanEdit = vm.UserId == CurrentUserId;
                vm.Permissions.CanFollow = vm.UserId != CurrentUserId;
                vm.Permissions.CanConnect = vm.UserId != CurrentUserId;


                if (notificationclicked != Guid.Empty)
                {
                    this.notificationAppService.MarkAsRead(notificationclicked);
                }
            }


            return View(vm);
        }

        [Route("profile/edit/{userId:guid}")]
        public IActionResult Edit(Guid userId)
        {
            ProfileViewModel vm = profileAppService.GetByUserId(userId, ProfileType.Personal);
            this.SetImages(vm);

            return View(vm);
        }

        [HttpPost]
        public IActionResult Save(ProfileViewModel vm, IFormFile avatar)
        {
            try
            {
                if (vm.Bio.Contains("is a game developer willing to rock the game development world with funny games."))
                {
                    vm.Bio = vm.Name + " is a game developer willing to rock the game development world with funny games.";
                }

                profileAppService.Save(this.CurrentUserId, vm);

                string url = Url.Action("Details", "Profile", new { area = string.Empty, id = vm.UserId.ToString() });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        private void SetImages(ProfileViewModel vm)
        {
            vm.ProfileImageUrl = UrlFormatter.ProfileImage(vm.UserId);
            vm.CoverImageUrl = UrlFormatter.ProfileCoverImage(vm.UserId, vm.Id);
        }


        private void FormatExternalNetworkUrls(ProfileViewModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.ItchIoUrl) && !vm.ItchIoUrl.EndsWith("itch.io"))
            {
                vm.ItchIoUrl = UrlFormatter.ItchIo(vm.ItchIoUrl);
            }

            if (!string.IsNullOrWhiteSpace(vm.GameJoltUrl) && !vm.GameJoltUrl.Contains("gamejolt.com"))
            {
                vm.GameJoltUrl = UrlFormatter.GameJolt(vm.GameJoltUrl);
            }

            if (!string.IsNullOrWhiteSpace(vm.UnityConnectUrl) && !vm.UnityConnectUrl.Contains("connect.unity.com"))
            {
                vm.UnityConnectUrl = UrlFormatter.UnityConnect(vm.UnityConnectUrl);
            }

            if (!string.IsNullOrWhiteSpace(vm.IndieDbUrl) && !vm.IndieDbUrl.Contains("indiedb.com"))
            {
                vm.IndieDbUrl = UrlFormatter.IndieDb(vm.IndieDbUrl);
            }

            if (!string.IsNullOrWhiteSpace(vm.GameDevNetUrl) && !vm.GameDevNetUrl.Contains("gamedev.net"))
            {
                vm.GameDevNetUrl = UrlFormatter.GamedevNet(vm.GameDevNetUrl);
            }
        }
    }
}