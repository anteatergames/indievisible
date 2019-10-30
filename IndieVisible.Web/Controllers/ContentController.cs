using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Poll;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Web.Controllers.Base;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Extensions;
using IndieVisible.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Controllers
{
    public class ContentController : SecureBaseController
    {
        private readonly IUserContentAppService userContentAppService;
        private readonly IGameAppService gameAppService;
        private readonly IGameFollowAppService gameFollowAppService;
        private readonly IUserFollowAppService userFollowAppService;
        private readonly INotificationAppService notificationAppService;

        public ContentController(IUserContentAppService userContentAppService
            , IGameAppService gameAppService
            , IGameFollowAppService gameFollowAppService
            , IUserFollowAppService userFollowAppService
            , INotificationAppService notificationAppService)
        {
            this.userContentAppService = userContentAppService;
            this.gameAppService = gameAppService;
            this.gameFollowAppService = gameFollowAppService;
            this.userFollowAppService = userFollowAppService;
            this.notificationAppService = notificationAppService;
        }

        [Route("content/{id:guid}")]
        public async Task<IActionResult> Details(Guid id, Guid notificationclicked)
        {
            notificationAppService.MarkAsRead(notificationclicked);

            OperationResultVo<UserContentViewModel> serviceResult = userContentAppService.GetById(CurrentUserId, id);

            if (!serviceResult.Success)
            {
                TempData["Message"] = SharedLocalizer["Content not found!"].Value;
                return RedirectToAction("Index", "Home");
            }

            UserContentViewModel vm = serviceResult.Value;

            vm.Content = ContentHelper.FormatContentToShow(vm.Content);

            SetAuthorDetails(vm);

            if (vm.GameId.HasValue && vm.GameId.Value != Guid.Empty)
            {
                OperationResultVo<Application.ViewModels.Game.GameViewModel> gameServiceResult = gameAppService.GetById(CurrentUserId, vm.GameId.Value);

                Application.ViewModels.Game.GameViewModel game = gameServiceResult.Value;

                vm.GameTitle = game.Title;
                vm.GameThumbnail = UrlFormatter.Image(game.UserId, BlobType.GameThumbnail, game.ThumbnailUrl);
            }

            vm.Content = vm.Content.Replace("image-style-align-right", "image-style-align-right float-right p-10");
            vm.Content = vm.Content.Replace("image-style-align-left", "image-style-align-left float-left p-10");
            vm.Content = vm.Content.Replace("<img src=", @"<img class=""img-fluid"" src=");

            if (string.IsNullOrEmpty(vm.Title))
            {
                vm.Title = SharedLocalizer["Content posted on"] + " " + vm.CreateDate.ToString();
            }

            if (string.IsNullOrWhiteSpace(vm.Introduction))
            {
                vm.Introduction = SharedLocalizer["Content posted on"] + " " + vm.CreateDate.ToShortDateString();
            }

            ApplicationUser user = await UserManager.FindByIdAsync(CurrentUserId.ToString());

            bool userIsAdmin = user != null && await UserManager.IsInRoleAsync(user, Roles.Administrator.ToString());

            vm.Permissions.CanEdit = vm.UserId == CurrentUserId || userIsAdmin;
            vm.Permissions.CanDelete = vm.UserId == CurrentUserId || userIsAdmin;

            return View(vm);
        }

        [Route("content/edit/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            OperationResultVo<UserContentViewModel> serviceResult = userContentAppService.GetById(CurrentUserId, id);

            UserContentViewModel vm = serviceResult.Value;

            IEnumerable<SelectListItemVo> games = gameAppService.GetByUser(vm.UserId);
            List<SelectListItem> gamesDropDown = games.ToSelectList();
            ViewBag.UserGames = gamesDropDown;

            if (!vm.HasFeaturedImage)
            {
                vm.FeaturedImage = Constants.DefaultFeaturedImage;
            }

            return View("CreateEdit", vm);
        }

        public IActionResult Add(Guid? gameId)
        {
            UserContentViewModel vm = new UserContentViewModel
            {
                UserId = CurrentUserId,
                FeaturedImage = Constants.DefaultFeaturedImage
            };

            IEnumerable<SelectListItemVo> games = gameAppService.GetByUser(vm.UserId);
            List<SelectListItem> gamesDropDown = games.ToSelectList();
            ViewBag.UserGames = gamesDropDown;

            if (gameId.HasValue)
            {
                vm.GameId = gameId;
            }

            return View("CreateEdit", vm);
        }

        [HttpPost]
        public IActionResult Save(UserContentViewModel vm)
        {
            try
            {
                ProfileViewModel profile = SetAuthorDetails(vm);

                OperationResultVo<Guid> saveResult = userContentAppService.Save(CurrentUserId, vm);

                if (!saveResult.Success)
                {
                    return Json(saveResult);
                }
                else
                {
                    NotifyFollowers(CurrentUserId, profile, vm.GameId, vm.Id);

                    string url = Url.Action("Index", "Home", new { area = string.Empty, id = vm.Id, pointsEarned = saveResult.PointsEarned });

                    return Json(new OperationResultRedirectVo(url));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [HttpDelete("/content/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            OperationResultVo result = userContentAppService.Remove(CurrentUserId, id);

            if (result.Success)
            {
                result.Message = SharedLocalizer["Content deleted successfully!"];
            }
            else
            {
                result.Message = SharedLocalizer["Oops! The content was not deleted!"];
            }

            return Json(result);
        }

        [HttpPost("content/post")]
        public IActionResult SimplePost(string text, string images, IEnumerable<PollOptionViewModel> pollOptions, SupportedLanguage? language)
        {
            UserContentViewModel vm = new UserContentViewModel
            {
                Language = language ?? SupportedLanguage.English,
                Content = text,
                Poll = new PollViewModel
                {
                    PollOptions = pollOptions.ToList()
                }
            };

            ProfileViewModel profile = SetAuthorDetails(vm);

            SetContentImages(vm, images);

            OperationResultVo<Guid> result = userContentAppService.Save(CurrentUserId, vm);

            NotifyFollowers(CurrentUserId, profile, vm.GameId, vm.Id);

            return Json(result);
        }


        [HttpPost]
        #region Content interactions
        [Route("content/like")]
        public IActionResult LikeContent(Guid targetId)
        {
            OperationResultVo response = userContentAppService.ContentLike(CurrentUserId, targetId);

            OperationResultVo<UserContentViewModel> content = userContentAppService.GetById(CurrentUserId, targetId);

            string myName = GetSessionValue(SessionValues.FullName);

            string text = String.Format(SharedLocalizer["{0} liked your post"], myName);

            string url = Url.Action("Details", "Content", new { id = targetId });

            notificationAppService.Notify(CurrentUserId, content.Value.UserId, NotificationType.ContentLike, targetId, text, url);

            return Json(response);
        }

        [HttpPost]
        [Route("content/unlike")]
        public IActionResult UnLikeContent(Guid targetId)
        {
            OperationResultVo response = userContentAppService.ContentUnlike(CurrentUserId, targetId);

            return Json(response);
        }


        [HttpPost]
        [Route("content/comment")]
        public IActionResult Comment(UserContentCommentViewModel vm)
        {
            OperationResultVo response;

            SetAuthorDetails(vm);

            response = userContentAppService.Comment(vm);

            return Json(response);
        }
        #endregion

        public IActionResult Feed(Guid? gameId, Guid? userId, Guid? oldestId, DateTime? oldestDate, bool? articlesOnly)
        {
            ViewComponentResult component = ViewComponent("Feed", new { count = 10, gameId, userId, oldestId, oldestDate, articlesOnly });

            return component;
        }

        private void SetContentImages(UserContentViewModel vm, string images)
        {
            if (images != null)
            {
                string[] imgSplit = images.Split('|');
                vm.Images = new List<string>();

                for (int i = 0; i < imgSplit.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(imgSplit[i]))
                    {
                        if (string.IsNullOrWhiteSpace(vm.FeaturedImage))
                        {
                            vm.FeaturedImage = imgSplit[i];
                        }
                        else
                        {
                            vm.Images.Add(imgSplit[i]);
                        }
                    }
                }
            }
        }

        private void NotifyFollowers(Guid userId, ProfileViewModel profile, Guid? gameId, Guid contentId)
        {
            Dictionary<Guid, FollowType> followers = new Dictionary<Guid, FollowType>();

            string notificationText = SharedLocalizer["{0} has posted a new content!"];
            string notificationUrl = Url.Action("Details", "Content", new { id = contentId });

            string gameName = string.Empty;

            Guid targetId = Guid.Empty;

            OperationResultListVo<UserFollowViewModel> userFollowers = userFollowAppService.GetByFollowedId(userId);

            if (userFollowers.Success)
            {
                foreach (UserFollowViewModel userFollower in userFollowers.Value)
                {
                    followers.Add(userFollower.UserId, FollowType.Content);
                }
            }

            gameName = CheckIfIsGamePost(gameId, followers, gameName);

            Notify(profile, followers, notificationText, notificationUrl, gameName, targetId);
        }

        private string CheckIfIsGamePost(Guid? gameId, Dictionary<Guid, FollowType> followers, string gameName)
        {
            if (gameId.HasValue)
            {
                OperationResultListVo<GameFollowViewModel> gameFollowResult = gameFollowAppService.GetByGameId(gameId.Value);

                OperationResultVo<GameViewModel> gameResult = gameAppService.GetById(CurrentUserId, gameId.Value);

                if (gameResult.Success)
                {
                    gameName = gameResult.Value.Title;
                }

                if (gameFollowResult.Success)
                {
                    foreach (GameFollowViewModel gameFollower in gameFollowResult.Value)
                    {
                        if (followers.ContainsKey(gameFollower.UserId))
                        {
                            followers[gameFollower.UserId] = FollowType.Game;
                        }
                        else
                        {
                            followers.Add(gameFollower.UserId, FollowType.Game);
                        }
                    }
                }
            }

            return gameName;
        }

        private void Notify(ProfileViewModel profile, Dictionary<Guid, FollowType> followers, string notificationText, string notificationUrl, string gameName, Guid targetId)
        {
            foreach (KeyValuePair<Guid, FollowType> follower in followers)
            {
                switch (follower.Value)
                {
                    case FollowType.Content:
                        notificationAppService.Notify(CurrentUserId, follower.Key, NotificationType.ContentPosted, targetId, String.Format(notificationText, profile.Name), notificationUrl);
                        break;
                    case FollowType.Game:
                        notificationAppService.Notify(CurrentUserId, follower.Key, NotificationType.ContentPosted, targetId, String.Format(notificationText, gameName), notificationUrl);
                        break;
                    default:
                        notificationAppService.Notify(CurrentUserId, follower.Key, NotificationType.ContentPosted, targetId, String.Format(notificationText, profile.Name), notificationUrl);
                        break;
                }
            }
        }
    }
}