using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Learn.Controllers.Base;
using IndieVisible.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Areas.Learn.Controllers
{
    public class StudyController : LearnBaseController
    {
        private readonly IStudyAppService studyAppService;

        public StudyController(IStudyAppService studyAppService)
        {
            this.studyAppService = studyAppService;
        }

        public IActionResult Index()
        {
            string studyProfile = StudyProfile.Student.ToString();

            if (User.Identity.IsAuthenticated)
            {
                studyProfile = GetSessionValue(SessionValues.StudyProfile);

                if (string.IsNullOrWhiteSpace(studyProfile))
                {
                    UserPreferencesViewModel userPreferences = UserPreferencesAppService.GetByUserId(CurrentUserId);
                    if (userPreferences == null || userPreferences.StudyProfile == 0)
                    {
                        return View("NoStudyProfile");
                    }
                    else
                    {
                        SetSessionValue(SessionValues.StudyProfile, userPreferences.StudyProfile.ToString());
                        studyProfile = userPreferences.StudyProfile.ToString();
                    }
                }
            }

            ViewData["studyProfile"] = studyProfile;

            switch (studyProfile)
            {
                case "Mentor":
                    return View("MentorDashboard");
                case "Student":
                    return View("StudentDashboard");
                default:
                    return View("StudentDashboard");
            }
        }

        [HttpPost("learn/study/setstudyprofile/{type}")]
        public IActionResult SetStudyProfile(StudyProfile type)
        {
            try
            {
                if (type == 0)
                {
                    type = StudyProfile.Student;
                }

                UserPreferencesViewModel userPreferences = UserPreferencesAppService.GetByUserId(CurrentUserId);

                if (userPreferences == null)
                {
                    userPreferences = new UserPreferencesViewModel
                    {
                        UserId = CurrentUserId
                    };
                }
                userPreferences.StudyProfile = type;

                OperationResultVo<Guid> saveResult = UserPreferencesAppService.Save(CurrentUserId, userPreferences);

                if (!saveResult.Success)
                {
                    return Json(new OperationResultVo(false, saveResult.Message));
                }

                SetSessionValue(SessionValues.StudyProfile, userPreferences.StudyProfile.ToString());

                string url = Url.Action("Index", "Study", new { area = "Learn" });

                return Json(new OperationResultRedirectVo(url, SharedLocalizer["Study Profile set successfully!"]));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [Route("learn/study/listmymentors")]
        public PartialViewResult ListMyMentors()
        {
            List<ProfileViewModel> model;

            OperationResultVo serviceResult = studyAppService.GetMyMentors(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultListVo<ProfileViewModel> castResult = serviceResult as OperationResultListVo<ProfileViewModel>;

                model = castResult.Value.ToList();
            }
            else
            {
                model = new List<ProfileViewModel>();
            }

            ViewData["ListDescription"] = SharedLocalizer["My Mentors"].ToString();

            return PartialView("_ListUsers", model);
        }


        [Route("learn/study/listmystudents")]
        public PartialViewResult ListMyStudents()
        {
            List<ProfileViewModel> model;

            OperationResultVo serviceResult = studyAppService.GetMyStudents(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultListVo<ProfileViewModel> castResult = serviceResult as OperationResultListVo<ProfileViewModel>;

                model = castResult.Value.ToList();
            }
            else
            {
                model = new List<ProfileViewModel>();
            }

            ViewData["ListDescription"] = SharedLocalizer["My Pupils"].ToString();

            return PartialView("_ListUsers", model);
        }

        [Route("learn/study/courses/explore")]
        public ActionResult ExploreCourses()
        {
            string studyProfile = GetSessionValue(SessionValues.StudyProfile);
            ViewData["studyProfile"] = studyProfile ?? "Student";

            return View();
        }
    }
}