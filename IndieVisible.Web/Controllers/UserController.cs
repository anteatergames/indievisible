using IndieVisible.Application;
using IndieVisible.Application.Formatters;
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
    public class UserController : SecureBaseController
    {
        private readonly IProfileAppService profileAppService;
        private readonly IUserConnectionAppService userConnectionAppService;
        private readonly INotificationAppService notificationAppService;

        public UserController(IProfileAppService profileAppService
            , IUserConnectionAppService userConnectionAppService
            , INotificationAppService notificationAppService) : base()
        {
            this.profileAppService = profileAppService;
            this.userConnectionAppService = userConnectionAppService;
            this.notificationAppService = notificationAppService;
        }

        public IActionResult Index()
        {
            ProfileViewModel model = FakeData.FakeProfile();

            return View(model);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult List()
        {
            OperationResultListVo<ProfileViewModel> serviceResult = profileAppService.GetAll(CurrentUserId);

            List<ProfileViewModel> profiles = serviceResult.Value.OrderByDescending(x => x.CreateDate).ToList();

            foreach (ProfileViewModel profile in profiles)
            {
                profile.ProfileImageUrl = UrlFormatter.ProfileImage(profile.UserId);
                profile.CoverImageUrl = UrlFormatter.ProfileCoverImage(profile.UserId, profile.Id);
            }

            return View(profiles);
        }


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
        [Route("user/connections/{userId:guid}")]
        public IActionResult Connections(Guid userId)
        {
            OperationResultListVo<UserConnectionViewModel> connections = userConnectionAppService.GetByUserId(userId);

            List<UserConnectionViewModel> model;

            if (connections.Success)
            {
                model = connections.Value.ToList();

                foreach (UserConnectionViewModel item in model)
                {
                    SetImages(item);
                }
            }
            else
            {
                model = new List<UserConnectionViewModel>();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }

            return View(model);
        }

        [HttpPost]
        [Route("user/connect")]
        public IActionResult ConnectToUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Connect(CurrentUserId, userId);

            string fullName = GetSessionValue(SessionValues.FullName);

            string text = String.Format(SharedLocalizer["{0} wants to connect."], fullName);

            string url = Url.Action("Details", "Profile", new { id = CurrentUserId });

            notificationAppService.Notify(userId, NotificationType.ConnectionRequest, userId, text, url);

            return Json(response);
        }

        [HttpPost]
        [Route("user/disconnect")]
        public IActionResult DisconnectUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Disconnect(CurrentUserId, userId);

            return Json(response);
        }


        [HttpPost]
        [Route("user/allowconnection")]
        public IActionResult AllowUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Allow(CurrentUserId, userId);

            return Json(response);
        }


        [HttpPost]
        [Route("user/denyconnection")]
        public IActionResult DenyUser(Guid userId)
        {
            OperationResultVo response = userConnectionAppService.Deny(CurrentUserId, userId);

            return Json(response);
        }
        #endregion

        private void SetImages(UserConnectionViewModel vm)
        {
            vm.ProfileImageUrl = UrlFormatter.ProfileImage(vm.TargetUserId);
            vm.CoverImageUrl = UrlFormatter.ProfileCoverImage(vm.TargetUserId, vm.ProfileId);
        }
    }
}