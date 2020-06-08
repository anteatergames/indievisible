using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Study;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Learn.Controllers.Base;
using IndieVisible.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPOI.OpenXmlFormats.Spreadsheet;
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


        [Route("learn/course/{id:guid}")]
        public ViewResult Details(Guid id)
        {
            StudyCourseViewModel model;

            OperationResultVo serviceResult = studyAppService.GetCourseById(CurrentUserId, id);

            if (serviceResult.Success)
            {
                OperationResultVo<StudyCourseViewModel> castResult = serviceResult as OperationResultVo<StudyCourseViewModel>;

                model = castResult.Value;
            }
            else
            {
                model = new StudyCourseViewModel();
            }

            return View("CourseDetailsWrapper", model);
        }


        [Route("learn/course/add")]
        public ViewResult AddCourse()
        {
            StudyCourseViewModel model;

            OperationResultVo serviceResult = studyAppService.GenerateNewCourse(CurrentUserId);

            OperationResultVo<StudyCourseViewModel> castResult = serviceResult as OperationResultVo<StudyCourseViewModel>;

            model = castResult.Value;

            return View("CourseCreateEditWrapper", model);
        }


        [Route("learn/course/edit/{id:guid}")]
        public ViewResult Edit(Guid id)
        {
            StudyCourseViewModel model;

            OperationResultVo serviceResult = studyAppService.GetCourseById(CurrentUserId, id);

            OperationResultVo<StudyCourseViewModel> castResult = serviceResult as OperationResultVo<StudyCourseViewModel>;

            model = castResult.Value;

            model.Description = ContentHelper.FormatCFormatTextAreaBreaks(model.Description);

            return View("CourseCreateEditWrapper", model);
        }


        [Route("learn/course/save")]
        public JsonResult SaveCourse(StudyCourseViewModel vm)
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


        [Route("learn/course/{courseId:guid}/listplans")]
        public PartialViewResult ListPlans(Guid courseId)
        {
            ViewData["ListDescription"] = SharedLocalizer["Study Plans"].ToString();

            var model = new List<StudyCourseListItemVo>();

            try
            {
                OperationResultVo result = studyAppService.GetPlans(CurrentUserId, courseId);

                if (result.Success)
                {
                    OperationResultListVo<StudyPlanViewModel> castResult = result as OperationResultListVo<StudyPlanViewModel>;

                    return PartialView("_ListPlans", castResult.Value);
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

            var model = new List<StudyCourseListItemVo>();

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

                if (result.Success)
                {
                    return Json(result);
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
    }
}