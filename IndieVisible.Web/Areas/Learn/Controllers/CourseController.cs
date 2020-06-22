using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Study;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Learn.Controllers.Base;
using IndieVisible.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Areas.Learn.Controllers
{
    public class CourseController : LearnBaseController
    {
        private readonly IStudyAppService studyAppService;

        public CourseController(IStudyAppService studyAppService)
        {
            this.studyAppService = studyAppService;
        }

        [Route("learn/course/listbyme")]
        public PartialViewResult ListByMe()
        {
            List<StudyCourseListItemVo> model;

            OperationResultVo serviceResult = studyAppService.GetCoursesByMe(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultListVo<StudyCourseListItemVo> castResult = serviceResult as OperationResultListVo<StudyCourseListItemVo>;

                model = castResult.Value.ToList();
            }
            else
            {
                model = new List<StudyCourseListItemVo>();
            }

            ViewData["ListDescription"] = SharedLocalizer["My Courses"].ToString();

            return PartialView("_ListCourses", model);
        }


        [Route("learn/course/listmine")]
        public PartialViewResult ListMine()
        {
            List<StudyCourseListItemVo> model;

            OperationResultVo serviceResult = studyAppService.GetMyCourses(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultListVo<StudyCourseListItemVo> castResult = serviceResult as OperationResultListVo<StudyCourseListItemVo>;

                model = castResult.Value.ToList();
            }
            else
            {
                model = new List<StudyCourseListItemVo>();
            }

            ViewData["ListDescription"] = SharedLocalizer["My Courses"].ToString();

            return PartialView("_ListCourses", model);
        }


        [Route("learn/course/list")]
        public PartialViewResult List(string backUrl)
        {
            List<StudyCourseListItemVo> model;

            OperationResultVo serviceResult = studyAppService.GetCourses(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultListVo<StudyCourseListItemVo> castResult = serviceResult as OperationResultListVo<StudyCourseListItemVo>;

                model = castResult.Value.ToList();
            }
            else
            {
                model = new List<StudyCourseListItemVo>();
            }

            ViewData["ListDescription"] = SharedLocalizer["Courses"].ToString();

            SetBackUrl(backUrl);

            return PartialView("_ListCoursesCards", model);
        }


        [Route("learn/course/{id:guid}")]
        public ViewResult Details(Guid id, string backUrl)
        {
            CourseViewModel vm;

            OperationResultVo serviceResult = studyAppService.GetCourseById(CurrentUserId, id);

            if (serviceResult.Success)
            {
                OperationResultVo<CourseViewModel> castResult = serviceResult as OperationResultVo<CourseViewModel>;

                vm = castResult.Value;
            }
            else
            {
                vm = new CourseViewModel();
            }

            FormatToShow(vm);

            SetBackUrl(backUrl);

            return View("CourseDetailsWrapper", vm);
        }

        [Route("learn/course/add")]
        public ViewResult AddCourse()
        {
            CourseViewModel model;

            OperationResultVo serviceResult = studyAppService.GenerateNewCourse(CurrentUserId);

            OperationResultVo<CourseViewModel> castResult = serviceResult as OperationResultVo<CourseViewModel>;

            model = castResult.Value;

            return View("CourseCreateEditWrapper", model);
        }


        [Route("learn/course/edit/{id:guid}")]
        public ViewResult Edit(Guid id)
        {
            CourseViewModel model;

            OperationResultVo serviceResult = studyAppService.GetCourseById(CurrentUserId, id);

            OperationResultVo<CourseViewModel> castResult = serviceResult as OperationResultVo<CourseViewModel>;

            model = castResult.Value;

            model.Description = ContentHelper.FormatCFormatTextAreaBreaks(model.Description);

            return View("CourseCreateEditWrapper", model);
        }


        [Route("learn/course/save")]
        public JsonResult SaveCourse(CourseViewModel vm)
        {
            bool isNew = vm.Id == Guid.Empty;

            try
            {
                vm.UserId = CurrentUserId;

                OperationResultVo<Guid> saveResult = studyAppService.SaveCourse(CurrentUserId, vm);

                if (saveResult.Success)
                {
                    //GenerateFeedPost(vm);

                    string url = Url.Action("details", "course", new { area = "learn", id = vm.Id });

                    if (isNew)
                    {
                        url = Url.Action("edit", "course", new { area = "learn", id = vm.Id, pointsEarned = saveResult.PointsEarned });

                        NotificationSender.SendTeamNotificationAsync("New Course created!");
                    }

                    return Json(new OperationResultRedirectVo<Guid>(saveResult, url));
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [Authorize]
        [HttpDelete("learn/course/delete/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                OperationResultVo saveResult = studyAppService.RemoveCourse(CurrentUserId, id);

                if (saveResult.Success)
                {
                    string url = Url.Action("index", "study", new { area = "learn" });

                    return Json(new OperationResultRedirectVo(saveResult, url));
                }
                else
                {
                    return Json(new OperationResultVo(false));
                }
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [Route("learn/course/{courseId:guid}/listplans")]
        public PartialViewResult ListPlans(Guid courseId)
        {
            ViewData["ListDescription"] = SharedLocalizer["Study Plans"].ToString();

            List<StudyCourseListItemVo> model = new List<StudyCourseListItemVo>();

            try
            {
                OperationResultVo result = studyAppService.GetPlans(CurrentUserId, courseId);

                if (result.Success)
                {
                    List<StudyPlanViewModel> castResult = (result as OperationResultListVo<StudyPlanViewModel>).Value.ToList();

                    FormatToShow(castResult);

                    return PartialView("_ListPlans", castResult);
                }
                else
                {
                    return PartialView("_ListPlans", model);
                }
            }
            catch (Exception ex)
            {
                return PartialView("_ListPlans", model);
            }
        }

        [Route("learn/course/{courseId:guid}/edit/plans/")]
        public PartialViewResult ListPlansForEdit(Guid courseId)
        {
            ViewData["ListDescription"] = SharedLocalizer["Study Plans"].ToString();

            List<StudyCourseListItemVo> model = new List<StudyCourseListItemVo>();

            try
            {
                OperationResultVo result = studyAppService.GetPlans(CurrentUserId, courseId);

                if (result.Success)
                {
                    OperationResultListVo<StudyPlanViewModel> castResult = result as OperationResultListVo<StudyPlanViewModel>;

                    return PartialView("_ListPlansForEdit", castResult.Value);
                }
                else
                {
                    return PartialView("_ListPlansForEdit", model);
                }
            }
            catch (Exception ex)
            {
                return PartialView("_ListPlansForEdit", model);
            }
        }

        [Authorize]
        [HttpPost("study/course/{courseId:guid}/saveplans/")]
        [RequestFormLimits(ValueCountLimit = int.MaxValue)]
        [RequestSizeLimit(int.MaxValue)]
        public IActionResult SavePlans(Guid courseId, IEnumerable<StudyPlanViewModel> plans)
        {
            try
            {
                OperationResultVo result = studyAppService.SavePlans(CurrentUserId, courseId, plans);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [Authorize]
        [HttpPost("study/course/{courseId:guid}/enroll/")]
        public IActionResult Enroll(Guid courseId)
        {
            try
            {
                OperationResultVo result = studyAppService.EnrollCourse(CurrentUserId, courseId);

                string url = Url.Action("details", "course", new { area = "learn", id = courseId });

                return Json(new OperationResultRedirectVo(result, url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [Authorize]
        [HttpPost("study/course/{courseId:guid}/leave/")]
        public IActionResult Leave(Guid courseId)
        {
            try
            {
                OperationResultVo result = studyAppService.LeaveCourse(CurrentUserId, courseId);

                string url = Url.Action("details", "course", new { area = "learn", id = courseId });

                return Json(new OperationResultRedirectVo(result, url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        private void FormatToShow(CourseViewModel model)
        {
            model.Description = String.IsNullOrWhiteSpace(model.Description) ? SharedLocalizer["No Description to show."] : model.Description.Replace("\n", "<br />");
        }

        private void FormatToShow(List<StudyPlanViewModel> castResult)
        {
            foreach (StudyPlanViewModel plan in castResult)
            {
                plan.Description = String.IsNullOrWhiteSpace(plan.Description) ? SharedLocalizer["No Description to show."] : plan.Description.Replace("\n", "<br />");
            }
        }

        private void SetBackUrl(string backUrl)
        {
            ViewData["BackUrl"] = string.IsNullOrWhiteSpace(backUrl) ? Url.Action("index", "study", new { area = "learn" }) : backUrl;
        }
    }
}