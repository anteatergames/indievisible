using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Controllers
{
    public class UserController : SecureBaseController
    {
        private readonly IProfileAppService _profileAppService;

        public UserController(IProfileAppService profileAppService) : base()
        {
            _profileAppService = profileAppService;
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
            OperationResultListVo<ProfileViewModel> serviceResult = _profileAppService.GetAll();

            List<ProfileViewModel> profiles = serviceResult.Value.OrderByDescending(x => x.CreateDate).ToList();

            foreach (var profile in profiles)
            {
                profile.ProfileImageUrl = UrlFormatter.ProfileImage(profile.UserId);
                profile.CoverImageUrl = UrlFormatter.ProfileCoverImage(profile.UserId, profile.Id);
            }

            return View(profiles);
        }
    }
}