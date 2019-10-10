using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using IndieVisible.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IndieVisible.Web.Controllers
{
    [Route("interact")]
    public class InteractionController : SecureBaseController
    {
        private readonly ILikeAppService likeAppService;
        private readonly IUserContentAppService userContentAppService;
        private readonly IGameAppService gameAppService;
        private readonly IUserContentCommentAppService userContentCommentAppService;
        private readonly INotificationAppService notificationAppService;
        private readonly IFollowAppService followAppService;
        private readonly IPollAppService pollAppService;

        public InteractionController(ILikeAppService likeAppService
            , IUserContentAppService userContentAppService
            , IGameAppService gameAppService
            , IUserContentCommentAppService userContentCommentAppService
            , INotificationAppService notificationAppService
            , IFollowAppService followAppService
            , IPollAppService pollAppService)
        {
            this.likeAppService = likeAppService;
            this.userContentAppService = userContentAppService;
            this.gameAppService = gameAppService;
            this.userContentCommentAppService = userContentCommentAppService;
            this.notificationAppService = notificationAppService;
            this.followAppService = followAppService;
            this.pollAppService = pollAppService;
        }


        [HttpPost]
        #region Content interactions
        [Route("content/like")]
        public IActionResult LikeContent(Guid targetId)
        {
            OperationResultVo response = likeAppService.ContentLike(CurrentUserId, targetId);

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
            OperationResultVo response = likeAppService.ContentUnlike(CurrentUserId, targetId);

            return Json(response);
        }


        [HttpPost]
        [Route("content/comment")]
        public IActionResult Comment(UserContentCommentViewModel vm)
        {
            OperationResultVo response;

            SetAuthorDetails(vm);

            response = userContentCommentAppService.Comment(vm);

            return Json(response);
        }
        #endregion



        #region Game Like/Unlike
        [HttpPost]
        [Route("game/like")]
        public IActionResult LikeGame(Guid likedId)
        {
            OperationResultVo response = likeAppService.GameLike(CurrentUserId, likedId);

            OperationResultVo<GameViewModel> gameResult = gameAppService.GetById(CurrentUserId, likedId);

            string fullName = GetSessionValue(SessionValues.FullName);

            string text = String.Format(SharedLocalizer["{0} loves your game {1}!"], fullName, gameResult.Value.Title);

            string url = Url.Action("Details", "Game", new { id = likedId });

            notificationAppService.Notify(CurrentUserId, gameResult.Value.UserId, NotificationType.ContentLike, likedId, text, url);


            return Json(response);
        }

        [HttpPost]
        [Route("game/unlike")]
        public IActionResult UnLikeGame(Guid likedId)
        {
            OperationResultVo response = likeAppService.GameUnlike(CurrentUserId, likedId);

            return Json(response);
        }
        #endregion



        #region Game Follow/Unfollow
        [HttpPost]
        [Route("game/follow")]
        public IActionResult FollowGame(Guid gameId)
        {
            OperationResultVo response = followAppService.GameFollow(CurrentUserId, gameId);

            OperationResultVo<GameViewModel> gameResult = gameAppService.GetById(CurrentUserId, gameId);

            string fullName = GetSessionValue(SessionValues.FullName);

            string text = String.Format(SharedLocalizer["{0} is following your game {1} now!"], fullName, gameResult.Value.Title);

            string url = Url.Action("Details", "Profile", new { id = CurrentUserId });

            notificationAppService.Notify(CurrentUserId, gameResult.Value.UserId, NotificationType.ContentLike, gameId, text, url);


            return Json(response);
        }

        [HttpPost]
        [Route("game/unfollow")]
        public IActionResult UnFollowGame(Guid gameId)
        {
            OperationResultVo response = followAppService.GameUnfollow(CurrentUserId, gameId);

            return Json(response);
        }
        #endregion



        #region User Follow/Unfollow
        [HttpPost]
        [Route("user/follow")]
        public IActionResult FollowUser(Guid userId)
        {
            OperationResultVo response = followAppService.UserFollow(CurrentUserId, userId);

            string fullName = GetSessionValue(SessionValues.FullName);

            string text = String.Format(SharedLocalizer["{0} is following you now!"], fullName);

            string url = Url.Action("Details", "Profile", new { id = CurrentUserId });

            notificationAppService.Notify(CurrentUserId, userId, NotificationType.ContentLike, userId, text, url);

            return Json(response);
        }

        [HttpPost]
        [Route("user/unfollow")]
        public IActionResult UnFollowUser(Guid userId)
        {
            OperationResultVo response = followAppService.UserUnfollow(CurrentUserId, userId);

            return Json(response);
        }
        #endregion


        #region Poll
        [HttpPost]
        [Route("poll/vote")]
        public IActionResult PollVote(Guid pollOptionId)
        {
            OperationResultVo response = pollAppService.PollVote(CurrentUserId, pollOptionId);

            return Json(response);
        }
        #endregion


        #region Private Methods
        private void SetAuthorDetails(UserContentCommentViewModel viewModel)
        {
            viewModel.UserId = CurrentUserId;
            viewModel.AuthorName = GetSessionValue(SessionValues.FullName);
            viewModel.AuthorPicture = UrlFormatter.ProfileImage(CurrentUserId);
        }
        #endregion
    }
}