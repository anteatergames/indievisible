using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IndieVisible.Web.Controllers
{
    [Route("interact")]
    public class InteractionController : SecureBaseController
    {
        private readonly ILikeAppService likeAppService;
        private readonly IProfileAppService profileAppService;
        private readonly IUserContentAppService userContentAppService;
        private readonly IGameAppService gameAppService;
        private readonly IUserContentCommentAppService userContentCommentAppService;
        private readonly IBrainstormAppService brainstormAppService;
        private readonly INotificationAppService notificationAppService;
        private readonly IFollowAppService followAppService;
        private readonly IUserConnectionAppService userConnectionAppService;

        public InteractionController(ILikeAppService likeAppService
            , IProfileAppService profileAppService
            , IUserContentAppService userContentAppService
            , IGameAppService gameAppService
            , IUserContentCommentAppService userContentCommentAppService
            , IBrainstormAppService brainstormAppService
            , INotificationAppService notificationAppService
            , IFollowAppService followAppService
            , IUserConnectionAppService userConnectionAppService)
        {
            this.likeAppService = likeAppService;
            this.profileAppService = profileAppService;
            this.userContentAppService = userContentAppService;
            this.gameAppService = gameAppService;
            this.userContentCommentAppService = userContentCommentAppService;
            this.brainstormAppService = brainstormAppService;
            this.notificationAppService = notificationAppService;
            this.followAppService = followAppService;
            this.userConnectionAppService = userConnectionAppService;
        }


        [HttpPost]
        #region Content interactions
        [Route("content/like")]
        public IActionResult LikeContent(Guid targetId)
        {
            likeAppService.CurrentUserId = this.CurrentUserId;
            OperationResultVo response = likeAppService.ContentLike(targetId);

            notificationAppService.CurrentUserId = this.CurrentUserId;
            OperationResultVo<UserContentViewModel> content = userContentAppService.GetById(targetId);

            ProfileViewModel myProfile = profileAppService.GetByUserId(this.CurrentUserId, this.CurrentUserId, ProfileType.Personal);

            string text = String.Format(SharedLocalizer["{0} liked your post"], myProfile.Name);

            string url = Url.Action("Details", "Content", new { id = targetId });

            OperationResultVo notificationResult = notificationAppService.Notify(content.Value.UserId, NotificationType.ContentLike, targetId, text, url);

            return Json(response);
        }

        [HttpPost]
        [Route("content/unlike")]
        public IActionResult UnLikeContent(Guid likedId)
        {
            likeAppService.CurrentUserId = this.CurrentUserId;
            OperationResultVo response = likeAppService.ContentUnlike(likedId);

            return Json(response);
        }


        [HttpPost]
        [Route("content/comment")]
        public IActionResult Comment(UserContentCommentViewModel vm)
        {
            OperationResultVo response;

            this.SetAuthorDetails(vm);

            switch (vm.UserContentType)
            {
                case UserContentType.Post:
                    response = userContentCommentAppService.Comment(vm);
                    break;
                case UserContentType.VotingItem:
                    response = brainstormAppService.Comment(vm);
                    break;
                default:
                    response = userContentCommentAppService.Comment(vm);
                    break;
            }

            return Json(response);
        } 
        #endregion



        #region Game Like/Unlike
        [HttpPost]
        [Route("game/like")]
        public IActionResult LikeGame(Guid likedId)
        {
            likeAppService.CurrentUserId = this.CurrentUserId;
            OperationResultVo response = likeAppService.GameLike(likedId);

            OperationResultVo<GameViewModel> gameResult = gameAppService.GetById(likedId);

            ProfileViewModel myProfile = profileAppService.GetByUserId(this.CurrentUserId, ProfileType.Personal);

            string text = String.Format(SharedLocalizer["{0} loves your game {1}!"], myProfile.Name, gameResult.Value.Title);

            string url = Url.Action("Details", "Game", new { id = likedId });

            OperationResultVo notificationResult = notificationAppService.Notify(gameResult.Value.UserId, NotificationType.ContentLike, likedId, text, url);


            return Json(response);
        }

        [HttpPost]
        [Route("game/unlike")]
        public IActionResult UnLikeGame(Guid likedId)
        {
            likeAppService.CurrentUserId = this.CurrentUserId;
            OperationResultVo response = likeAppService.GameUnlike(likedId);

            return Json(response);
        }
        #endregion



        #region Game Follow/Unfollow
        [HttpPost]
        [Route("game/follow")]
        public IActionResult FollowGame(Guid gameId)
        {
            OperationResultVo response = followAppService.GameFollow(this.CurrentUserId, gameId);

            OperationResultVo<GameViewModel> gameResult = gameAppService.GetById(gameId);

            ProfileViewModel myProfile = profileAppService.GetByUserId(this.CurrentUserId, ProfileType.Personal);

            string text = String.Format(SharedLocalizer["{0} is following your game {1} now!"], myProfile.Name, gameResult.Value.Title);

            string url = Url.Action("Details", "Profile", new { id = this.CurrentUserId });

            OperationResultVo notificationResult = notificationAppService.Notify(gameResult.Value.UserId, NotificationType.ContentLike, gameId, text, url);


            return Json(response);
        }

        [HttpPost]
        [Route("game/unfollow")]
        public IActionResult UnFollowGame(Guid gameId)
        {
            OperationResultVo response = followAppService.GameUnfollow(this.CurrentUserId, gameId);

            return Json(response);
        }
        #endregion



        #region User Follow/Unfollow
        [HttpPost]
        [Route("user/follow")]
        public IActionResult FollowUser(Guid userId)
        {
            OperationResultVo response = followAppService.UserFollow(this.CurrentUserId, userId);

            ProfileViewModel myProfile = profileAppService.GetByUserId(this.CurrentUserId, ProfileType.Personal);

            string text = String.Format(SharedLocalizer["{0} is following you now!"], myProfile.Name);

            string url = Url.Action("Details", "Profile", new { id = this.CurrentUserId });

            OperationResultVo notificationResult = notificationAppService.Notify(userId, NotificationType.ContentLike, userId, text, url);

            return Json(response);
        }

        [HttpPost]
        [Route("user/unfollow")]
        public IActionResult UnFollowUser(Guid userId)
        {
            OperationResultVo response = followAppService.UserUnfollow(this.CurrentUserId, userId);

            return Json(response);
        }
        #endregion



        #region User Connect/Disconnect
        [HttpPost]
        [Route("user/connect")]
        public IActionResult ConnectToUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Connect(this.CurrentUserId, userId);

            ProfileViewModel myProfile = profileAppService.GetByUserId(this.CurrentUserId, ProfileType.Personal);

            string text = String.Format(SharedLocalizer["{0} wants to connect."], myProfile.Name);

            string url = Url.Action("Details", "Profile", new { id = this.CurrentUserId });

            OperationResultVo notificationResult = notificationAppService.Notify(userId, NotificationType.ConnectionRequest, userId, text, url);

            TranslateResponse(response);

            return Json(response);
        }

        [HttpPost]
        [Route("user/disconnect")]
        public IActionResult DisconnectUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Disconnect(this.CurrentUserId, userId);

            TranslateResponse(response);

            return Json(response);
        }


        [Route("user/allowconnection")]
        public IActionResult AllowUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Allow(this.CurrentUserId, userId);

            TranslateResponse(response);

            return Json(response);
        }
        [Route("user/denyconnection")]
        public IActionResult DenyUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Deny(this.CurrentUserId, userId);

            TranslateResponse(response);

            return Json(response);
        }
        #endregion


        #region Private Methods
        private void SetAuthorDetails(UserContentCommentViewModel viewModel)
        {
            ProfileViewModel profile = ProfileAppService.GetByUserId(CurrentUserId, ProfileType.Personal);

            if (profile != null)
            {
                viewModel.AuthorName = profile.Name;
                viewModel.AuthorPicture = profile.ProfileImageUrl;
            }

            viewModel.UserId = CurrentUserId;
        }

        private void TranslateResponse(OperationResultVo response)
        {
            if (response != null && !String.IsNullOrWhiteSpace(response.Message))
            {
                response.Message = SharedLocalizer[response.Message];
            }
        }
        #endregion
    }
}