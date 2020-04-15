using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Extensions;
using IndieVisible.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Controllers
{
    [Route("user")]
    public class UserController : SecureBaseController
    {
        private readonly IProfileAppService profileAppService;
        private readonly INotificationAppService notificationAppService;

        public UserController(IProfileAppService profileAppService
            , INotificationAppService notificationAppService) : base()
        {
            this.profileAppService = profileAppService;
            this.notificationAppService = notificationAppService;
        }

        public IActionResult Index()
        {
            ProfileViewModel model = profileAppService.GenerateNewOne(ProfileType.Personal);

            return View(model);
        }

        [Route("edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [Route("list")]
        public IActionResult List()
        {
            OperationResultListVo<ProfileViewModel> serviceResult = profileAppService.GetAll(CurrentUserId);

            List<ProfileViewModel> profiles = serviceResult.Value.OrderByDescending(x => x.CreateDate).ToList();

            return View(profiles);
        }

        #region User Follow/Unfollow

        [HttpPost]
        [Route("follow")]
        public IActionResult FollowUser(Guid userId)
        {
            OperationResultVo response = profileAppService.UserFollow(CurrentUserId, userId);

            string fullName = GetSessionValue(SessionValues.FullName);

            string text = String.Format(SharedLocalizer["{0} is following you now!"], fullName);

            string url = Url.Action("Details", "Profile", new { id = CurrentUserId });

            notificationAppService.Notify(CurrentUserId, userId, NotificationType.ContentLike, userId, text, url);

            return Json(response);
        }

        [HttpPost]
        [Route("unfollow")]
        public IActionResult UnFollowUser(Guid userId)
        {
            OperationResultVo response = profileAppService.UserUnfollow(CurrentUserId, userId);

            return Json(response);
        }

        #endregion User Follow/Unfollow

        [Route("search")]
        public IActionResult Search(string term)
        {
            Select2SearchResultViewModel vm = new Select2SearchResultViewModel();

            OperationResultVo serviceResult = profileAppService.Search(term);

            if (serviceResult.Success)
            {
                IEnumerable<ProfileSearchViewModel> searchResults = ((OperationResultListVo<ProfileSearchViewModel>)serviceResult).Value;

                foreach (ProfileSearchViewModel item in searchResults)
                {
                    Select2SearchResultItemViewModel s2obj = new Select2SearchResultItemViewModel
                    {
                        Id = item.UserId.ToString(),
                        Text = item.Name
                    };

                    vm.Results.Add(s2obj);
                }

                return Json(vm);
            }
            else
            {
                return Json(serviceResult);
            }
        }

        #region User Connection

        [HttpGet]
        [Route("connections/{userId:guid}")]
        public IActionResult Connections(Guid userId)
        {
            OperationResultListVo<UserConnectionViewModel> connections = (OperationResultListVo<UserConnectionViewModel>)profileAppService.GetConnectionsByUserId(userId);

            List<UserConnectionViewModel> model;

            if (connections.Success)
            {
                model = connections.Value.ToList();
            }
            else
            {
                model = new List<UserConnectionViewModel>();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Shared/_Connections.cshtml", model);
            }

            return View("~/Views/Shared/_Connections.cshtml", model);
        }

        [HttpPost]
        [Route("connect")]
        public IActionResult ConnectToUser(Guid userId)
        {
            OperationResultVo response = profileAppService.Connect(CurrentUserId, userId);

            string fullName = GetSessionValue(SessionValues.FullName);

            string text = String.Format(SharedLocalizer["{0} wants to connect."], fullName);

            string url = Url.Action("Details", "Profile", new { id = CurrentUserId });

            notificationAppService.Notify(CurrentUserId, userId, NotificationType.ConnectionRequest, userId, text, url);

            return Json(response);
        }

        [HttpPost]
        [Route("disconnect")]
        public IActionResult DisconnectUser(Guid userId)
        {
            OperationResultVo response = profileAppService.Disconnect(CurrentUserId, userId);

            return Json(response);
        }

        [HttpPost]
        [Route("allowconnection")]
        public IActionResult AllowUser(Guid userId)
        {
            OperationResultVo response = profileAppService.Allow(CurrentUserId, userId);

            return Json(response);
        }

        [HttpPost]
        [Route("denyconnection")]
        public IActionResult DenyUser(Guid userId)
        {
            OperationResultVo response = profileAppService.Deny(CurrentUserId, userId);

            return Json(response);
        }

        #endregion User Connection
    }
}