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
                profile.UserId = id;
                profileAppService.Save(CurrentUserId, profile);

                vm = profile;
            }

            SetImages(vm);

            FormatExternalNetworkUrls(vm);

            FormatExternaLinks(vm);

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
            ProfileViewModel vm = profileAppService.GetByUserId(userId, ProfileType.Personal);

            FormatExternalLinksForEdit(vm);

            SetImages(vm);

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

                profileAppService.Save(CurrentUserId, vm);

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

        private static void FormatExternalLinksForEdit(ProfileViewModel vm)
        {
            foreach (ExternalLinkProvider provider in Enum.GetValues(typeof(ExternalLinkProvider)))
            {
                var existingProvider = vm.ExternalLinks.FirstOrDefault(x => x.Provider == provider);
                var uiInfo = provider.GetAttributeOfType<UiInfoAttribute>();

                if (existingProvider == null)
                {

                    var placeHolder = new UserProfileExternalLinkViewModel
                    {
                        UserProfileId = vm.Id,
                        UserId = vm.UserId,
                        Type =  (ExternalLinkType)uiInfo.Type,
                        Provider = provider,
                        Display = uiInfo.Display,
                        UiClass = uiInfo.Class
                    };

                    vm.ExternalLinks.Add(placeHolder);
                }
                else
                {
                    existingProvider.Display = uiInfo.Display;
                    existingProvider.UiClass = uiInfo.Class;
                }
            }

            vm.ExternalLinks = vm.ExternalLinks.OrderByDescending(x => x.Type).ThenBy(x => x.Provider).ToList();
        }

        private void FormatExternaLinks(ProfileViewModel vm)
        {
            foreach (var item in vm.ExternalLinks)
            {
                switch (item.Provider)
                {
                    case ExternalLinkProvider.Website:
                        item.Value = UrlFormatter.Website(item.Value);
                        break;
                    case ExternalLinkProvider.Facebook:
                        item.Value = UrlFormatter.Facebook(item.Value);
                        break;
                    case ExternalLinkProvider.Twitter:
                        item.Value = UrlFormatter.Twitter(item.Value);
                        break;
                    case ExternalLinkProvider.Instagram:
                        item.Value = UrlFormatter.Instagram(item.Value);
                        break;
                    case ExternalLinkProvider.Youtube:
                        item.Value = UrlFormatter.Youtube(item.Value);
                        break;
                    case ExternalLinkProvider.XboxLive:
                        item.Value = UrlFormatter.XboxLive(item.Value);
                        break;
                    case ExternalLinkProvider.Psn:
                        item.Value = UrlFormatter.Psn(item.Value);
                        break;
                    case ExternalLinkProvider.Steam:
                        item.Value = UrlFormatter.Steam(item.Value);
                        break;
                    case ExternalLinkProvider.GameJolt:
                        item.Value = UrlFormatter.GameJolt(item.Value);
                        break;
                }
            }
        }
    }
}