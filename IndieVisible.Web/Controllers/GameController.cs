using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Controllers
{
    public class GameController : SecureBaseController
    {
        private readonly IGameAppService _gameAppService;
        private readonly INotificationAppService notificationAppService;

        public GameController(IGameAppService gameAppService
            , INotificationAppService notificationAppService) : base()
        {
            _gameAppService = gameAppService;
            this.notificationAppService = notificationAppService;
        }

        [Route("game/{id:guid}")]
        public async Task<IActionResult> Details(Guid id, Guid notificationclicked)
        {
            OperationResultVo<GameViewModel> serviceResult = _gameAppService.GetById(CurrentUserId, id);

            GameViewModel vm = serviceResult.Value;

            SetImages(vm);

            FormatExternaLinks(vm);

            bool isAdmin = false;

            if (!CurrentUserId.Equals(Guid.Empty))
            {
                ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());
                bool userIsAdmin = await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());

                isAdmin = user != null && userIsAdmin;
            }

            vm.Permissions.CanEdit = vm.UserId == CurrentUserId || isAdmin;
            vm.Permissions.CanPostActivity = vm.UserId == CurrentUserId;

            notificationAppService.MarkAsRead(notificationclicked);

            return View(vm);
        }

        [Route("games/{genre:alpha?}")]
        public IActionResult List(GameGenre genre)
        {
            IEnumerable<GameListItemViewModel> latest = _gameAppService.GetLatest(CurrentUserId, 99, Guid.Empty, genre);

            ViewBag.Games = latest;
            ViewData["Genre"] = genre;
            ViewData["Title"] = genre == 0 ? SharedLocalizer["Games"] : SharedLocalizer[genre.ToString() + " Games"];
            ViewData["Description"] = SharedLocalizer["Check awesome " + genre.ToString() + " Games"];

            return View();
        }

        public IActionResult Add()
        {
            GameViewModel vm = new GameViewModel
            {
                Engine = GameEngine.Unity,
                UserId = CurrentUserId,
                CoverImageUrl = Constants.DefaultGameCoverImage,
                ThumbnailUrl = Constants.DefaultGameThumbnail
            };

            return View("CreateEdit", vm);
        }

        public IActionResult Edit(Guid id)
        {
            OperationResultVo<GameViewModel> serviceResult = _gameAppService.GetById(CurrentUserId, id);

            GameViewModel vm = serviceResult.Value;

            FormatExternalLinksForEdit(vm);

            SetImages(vm);

            return View("CreateEdit", vm);
        }

        [HttpPost]
        public IActionResult Save(GameViewModel vm, IFormFile thumbnail)
        {
            try
            {
                SetAuthorDetails(vm);
                ClearImagesUrl(vm);

                _gameAppService.Save(CurrentUserId, vm);

                string url = Url.Action("Details", "Game", new { area = string.Empty, id = vm.Id.ToString() });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        public IActionResult Latest(int qtd, Guid userId)
        {
            return ViewComponent("LatestGames", new { qtd, userId });
        }

        private void SetImages(GameViewModel vm)
        {
            vm.ThumbnailUrl = string.IsNullOrWhiteSpace(vm.ThumbnailUrl) || Constants.DefaultGameThumbnail.Contains(vm.ThumbnailUrl) ? Constants.DefaultGameThumbnail : UrlFormatter.Image(vm.UserId, BlobType.GameThumbnail, vm.ThumbnailUrl);

            vm.CoverImageUrl = string.IsNullOrWhiteSpace(vm.CoverImageUrl) || Constants.DefaultGameCoverImage.Contains(vm.CoverImageUrl) ? Constants.DefaultGameCoverImage : UrlFormatter.Image(vm.UserId, BlobType.GameCover, vm.CoverImageUrl);

            vm.AuthorPicture = UrlFormatter.ProfileImage(vm.UserId);
        }

        private void SetAuthorDetails(GameViewModel vm)
        {
            if (vm.Id == Guid.Empty || vm.UserId == Guid.Empty || vm.UserId == CurrentUserId)
            {
                vm.UserId = CurrentUserId;
                ProfileViewModel profile = ProfileAppService.GetByUserId(CurrentUserId, ProfileType.Personal);

                if (profile != null)
                {
                    vm.AuthorName = profile.Name;
                    vm.AuthorPicture = profile.ProfileImageUrl;
                }
            }
        }

        private void ClearImagesUrl(GameViewModel vm)
        {
            vm.ThumbnailUrl = GetUrlLastPart(vm.ThumbnailUrl);
            vm.CoverImageUrl = GetUrlLastPart(vm.CoverImageUrl);
        }

        private static string GetUrlLastPart(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return url;
            }
            else
            {
                string[] split = url.Split('/');
                return split[split.Length - 1];
            }
        }


        private static void FormatExternalLinksForEdit(GameViewModel vm)
        {
            foreach (ExternalLinkProvider provider in Enum.GetValues(typeof(ExternalLinkProvider)))
            {
                GameExternalLinkViewModel existingProvider = vm.ExternalLinks.FirstOrDefault(x => x.Provider == provider);
                ExternalLinkInfoAttribute uiInfo = provider.GetAttributeOfType<ExternalLinkInfoAttribute>();

                if (existingProvider == null)
                {
                    GameExternalLinkViewModel placeHolder = new GameExternalLinkViewModel
                    {
                        GameId = vm.Id,
                        UserId = vm.UserId,
                        Type = uiInfo.Type,
                        Provider = provider,
                        Display = uiInfo.Display,
                        IconClass = uiInfo.Class,
                        ColorClass = uiInfo.ColorClass,
                        IsStore = uiInfo.IsStore
                    };

                    vm.ExternalLinks.Add(placeHolder);
                }
                else
                {
                    existingProvider.Display = uiInfo.Display;
                    existingProvider.IconClass = uiInfo.Class;
                }
            }

            vm.ExternalLinks = vm.ExternalLinks.OrderByDescending(x => x.Type).ThenBy(x => x.Provider).ToList();
        }

        private void FormatExternaLinks(GameViewModel vm)
        {
            foreach (var item in vm.ExternalLinks)
            {
                ExternalLinkInfoAttribute uiInfo = item.Provider.GetAttributeOfType<ExternalLinkInfoAttribute>();
                item.Display = uiInfo.Display;
                item.IconClass = uiInfo.Class;
                item.ColorClass = uiInfo.ColorClass;
                item.IsStore = uiInfo.IsStore;

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
                        item.Value = UrlFormatter.XboxLiveGame(item.Value);
                        break;
                    case ExternalLinkProvider.PlaystationStore:
                        item.Value = UrlFormatter.PlayStationStoreGame(item.Value);
                        break;
                    case ExternalLinkProvider.Steam:
                        item.Value = UrlFormatter.SteamGame(item.Value);
                        break;
                    case ExternalLinkProvider.GameJolt:
                        item.Value = UrlFormatter.GameJoltGame(item.Value);
                        break;
                    case ExternalLinkProvider.ItchIo:
                        item.Value = UrlFormatter.ItchIoGame(item.Value);
                        break;
                    case ExternalLinkProvider.GamedevNet:
                        item.Value = UrlFormatter.GamedevNetGame(item.Value);
                        break;
                    case ExternalLinkProvider.IndieDb:
                        item.Value = UrlFormatter.IndieDbGame(item.Value);
                        break;
                    case ExternalLinkProvider.UnityConnect:
                        item.Value = UrlFormatter.UnityConnectGame(item.Value);
                        break;
                    case ExternalLinkProvider.GooglePlayStore:
                        item.Value = UrlFormatter.GooglePlayStoreGame(item.Value);
                        break;
                    case ExternalLinkProvider.AppleAppStore:
                        item.Value = UrlFormatter.AppleAppStoreGame(item.Value);
                        break;
                }
            }
        }
    }
}