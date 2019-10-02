using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using IndieVisible.Web.Extensions;
using IndieVisible.Web.Models;
using Microsoft.AspNetCore.Authorization;
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

        public UserController(IProfileAppService profileAppService, IUserConnectionAppService userConnectionAppService) : base()
        {
            this.profileAppService = profileAppService;
            this.userConnectionAppService = userConnectionAppService;
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

        [Authorize]
        public IActionResult List()
        {
            OperationResultListVo<ProfileViewModel> serviceResult = profileAppService.GetAll();

            List<ProfileViewModel> profiles = serviceResult.Value.OrderByDescending(x => x.CreateDate).ToList();

            foreach (ProfileViewModel profile in profiles)
            {
                profile.ProfileImageUrl = UrlFormatter.ProfileImage(profile.UserId);
                profile.CoverImageUrl = UrlFormatter.ProfileCoverImage(profile.UserId, profile.Id);
            }

            return View(profiles);
        }

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
                    this.SetImages(item);
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

        private void SetImages(UserConnectionViewModel vm)
        {
            vm.ProfileImageUrl = UrlFormatter.ProfileImage(vm.TargetUserId);
            vm.CoverImageUrl = UrlFormatter.ProfileCoverImage(vm.TargetUserId, vm.ProfileId);
        }


        public IActionResult Search(string term)
        {
            var vm = new Select2SearchResultViewModel();

            var serviceResult = profileAppService.Search(term);

            if (serviceResult.Success)
            {
                var searchResults = ((OperationResultListVo<ProfileSearchViewModel>)serviceResult).Value;

                foreach (var item in searchResults)
                {
                    var s2obj = new Select2SearchResultItemViewModel
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
    }
}