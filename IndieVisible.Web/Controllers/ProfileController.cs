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
        private readonly IProfileAppService _profileAppService;
        private readonly INotificationAppService notificationAppService;

        public ProfileController(IProfileAppService profileAppService
            , INotificationAppService notificationAppService) : base()
        {
            _profileAppService = profileAppService;
            this.notificationAppService = notificationAppService;
        }

        [HttpGet]
        [Route("profile/{id:guid}")]
        public async Task<IActionResult> Details(Guid id, Guid notificationclicked)
        {
            ProfileViewModel vm = _profileAppService.GetByUserId(this.CurrentUserId, id, ProfileType.Personal);
            if (vm == null)
            {
                ProfileViewModel profile = _profileAppService.GenerateNewOne(ProfileType.Personal);
                profile.UserId = id;
                _profileAppService.Save(profile);

                vm = profile;
            }

            this.SetImages(vm);

            if (this.CurrentUserId != Guid.Empty)
            {
                ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());
                bool userIsAdmin = user == null ? false : await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());
                vm.Permissions.CanEdit = vm.UserId == CurrentUserId || userIsAdmin;

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
            ProfileViewModel vm = _profileAppService.GetByUserId(userId, ProfileType.Personal);
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

                _profileAppService.Save(vm);

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
    }
}