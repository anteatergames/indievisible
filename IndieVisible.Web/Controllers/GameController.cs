using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            _gameAppService.CurrentUserId = this.CurrentUserId;
            OperationResultVo<GameViewModel> serviceResult = _gameAppService.GetById(id);

            GameViewModel vm = serviceResult.Value;
            this.SetImages(vm);

            ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());
            bool userIsAdmin = await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());

            bool isAdmin = user != null && userIsAdmin;

            vm.Permissions.CanEdit = vm.UserId == CurrentUserId || isAdmin;
            vm.Permissions.CanPostActivity = vm.UserId == CurrentUserId;

            this.notificationAppService.MarkAsRead(notificationclicked);

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
            GameViewModel vm = new GameViewModel();
            vm.UserId = CurrentUserId;
            vm.CoverImageUrl = Constants.DefaultGameCoverImage;
            vm.ThumbnailUrl = Constants.DefaultGameThumbnail;

            return View("CreateEdit", vm);
        }

        public IActionResult Edit(Guid id)
        {
            OperationResultVo<GameViewModel> serviceResult = _gameAppService.GetById(id);

            GameViewModel vm = serviceResult.Value;
            this.SetImages(vm);

            return View("CreateEdit", vm);
        }

        [HttpPost]
        public IActionResult Save(GameViewModel vm, IFormFile thumbnail)
        {
            try
            {
                this.SetAuthorDetails(vm);
                this.ClearImagesUrl(vm);

                _gameAppService.Save(vm);

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
    }
}