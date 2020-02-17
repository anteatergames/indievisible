﻿using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Jobs;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.CrossCutting.Identity.Services;
using IndieVisible.Web.Areas.Work.Controllers.Base;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Areas.Work.Controllers
{
    public class JobPositionController : WorkBaseController
    {
        private readonly IJobPositionAppService jobPositionAppService;
        private readonly IUserContentAppService userContentAppService;

        public JobPositionController(IJobPositionAppService jobPositionAppService
            , IUserContentAppService userContentAppService)
        {
            this.jobPositionAppService = jobPositionAppService;
            this.userContentAppService = userContentAppService;
        }

        public IActionResult Index()
        {

            string jobProfile = JobProfile.Applicant.ToString();

            if (User.Identity.IsAuthenticated)
            {
                jobProfile = GetSessionValue(SessionValues.JobProfile);

                if (string.IsNullOrWhiteSpace(jobProfile))
                {
                    UserPreferencesViewModel userPreferences = UserPreferencesAppService.GetByUserId(CurrentUserId);
                    if (userPreferences == null || userPreferences.JobProfile == 0)
                    {
                        return View("NoJobProfile");
                    }
                    else
                    {
                        SetSessionValue(SessionValues.JobProfile, userPreferences.JobProfile.ToString());
                        jobProfile = userPreferences.JobProfile.ToString();
                    }
                }
            }

            ViewData["jobProfile"] = jobProfile;

            return View();
        }

        [HttpPost("work/jobposition/setjobprofile/{type}")]
        public IActionResult SetJobProfile(JobProfile type)
        {
            try
            {
                if (type == 0)
                {
                    type = JobProfile.Applicant;
                }

                UserPreferencesViewModel userPreferences = UserPreferencesAppService.GetByUserId(CurrentUserId);

                if (userPreferences == null)
                {
                    userPreferences = new UserPreferencesViewModel();
                    userPreferences.UserId = CurrentUserId;
                }
                userPreferences.JobProfile = type;

                OperationResultVo<Guid> saveResult = UserPreferencesAppService.Save(CurrentUserId, userPreferences);

                if (!saveResult.Success)
                {
                    return Json(new OperationResultVo(false, saveResult.Message));
                }


                SetSessionValue(SessionValues.JobProfile, userPreferences.JobProfile.ToString());


                string url = Url.Action("Index", "JobPosition", new { area = "Work" });

                return Json(new OperationResultRedirectVo(url, SharedLocalizer["Job Profile set successfully!"]));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }


        [Route("work/jobposition/list/{employerId:guid?}")]
        [Route("work/jobposition/list")]
        public PartialViewResult List(Guid? employerId)
        {
            IEnumerable<JobPositionViewModel> model;
            OperationResultVo serviceResult;

            if (employerId.HasValue)
            {

                ViewData["ListDescription"] = "These are the job positions you posted.";
                serviceResult = jobPositionAppService.GetAllMine(employerId.Value);
            }
            else
            {

                ViewData["ListDescription"] = "Here you can see the currently available job positions.";
                serviceResult = jobPositionAppService.GetAllAvailable(CurrentUserId);
            }

            if (serviceResult != null && serviceResult.Success)
            {
                OperationResultListVo<JobPositionViewModel> castResult = serviceResult as OperationResultListVo<JobPositionViewModel>;

                model = castResult.Value;
            }
            else
            {
                model = new List<JobPositionViewModel>();
            }

            foreach (JobPositionViewModel item in model)
            {
                SetLocalization(item);
            }

            return PartialView("_List", model);
        }

        [Route("work/jobposition/listmine")]
        public PartialViewResult ListMine()
        {
            List<JobPositionViewModel> model;

            OperationResultVo serviceResult = jobPositionAppService.GetAllMine(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultListVo<JobPositionViewModel> castResult = serviceResult as OperationResultListVo<JobPositionViewModel>;

                model = castResult.Value.ToList();
            }
            else
            {
                model = new List<JobPositionViewModel>();
            }

            foreach (JobPositionViewModel item in model)
            {
                SetLocalization(item);
            }

            return PartialView("_List", model);
        }

        [Route("work/jobposition/mypositionsstats")]
        public PartialViewResult MyPositionsStats()
        {
            Dictionary<string, int> model;

            OperationResultVo serviceResult = jobPositionAppService.GetMyPositionsStats(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultVo<Dictionary<string, int>> castResult = serviceResult as OperationResultVo<Dictionary<string, int>>;

                model = castResult.Value;
            }
            else
            {
                model = new Dictionary<string, int>();
            }

            return PartialView("_MyPositionsStats", model);
        }

        [Route("work/jobposition/myapplications")]
        public PartialViewResult MyApplications()
        {
            List<JobPositionApplicationVo> model;

            OperationResultVo serviceResult = jobPositionAppService.GetMyApplications(CurrentUserId);

            if (serviceResult.Success)
            {
                OperationResultListVo<JobPositionApplicationVo> castResult = serviceResult as OperationResultListVo<JobPositionApplicationVo>;

                model = castResult.Value.ToList();
            }
            else
            {
                model = new List<JobPositionApplicationVo>();
            }

            return PartialView("_MyApplications", model);
        }

        [Route("work/jobposition/details/{id:guid}")]
        public IActionResult Details(Guid id, int? pointsEarned)
        {
            OperationResultVo<JobPositionViewModel> op = jobPositionAppService.GetById(CurrentUserId, id);

            JobPositionViewModel vm = op.Value;

            SetLocalization(vm);
            SetAuthorDetails(vm);
            vm.Description = ContentHelper.FormatContentToShow(vm.Description);

            SetGamificationMessage(pointsEarned);

            return View("_Details", vm);
        }


        [Authorize]
        [Route("work/jobposition/new/{origin}")]
        public IActionResult New(JobPositionOrigin origin)
        {
            OperationResultVo serviceResult = jobPositionAppService.GenerateNewTeam(CurrentUserId, origin);

            if (serviceResult.Success)
            {
                OperationResultVo<JobPositionViewModel> castResult = serviceResult as OperationResultVo<JobPositionViewModel>;

                JobPositionViewModel model = castResult.Value;

                SetLocalization(model);

                return PartialView("_CreateEdit", model);
            }
            else
            {
                return PartialView("_CreateEdit", new JobPositionViewModel());
            }
        }


        [Authorize]
        [Route("work/jobposition/edit/{jobPositionId:guid}")]
        public IActionResult Edit(Guid jobPositionId)
        {
            OperationResultVo serviceResult = jobPositionAppService.GetById(CurrentUserId, jobPositionId);

            if (serviceResult.Success)
            {
                OperationResultVo<JobPositionViewModel> castResult = serviceResult as OperationResultVo<JobPositionViewModel>;

                JobPositionViewModel model = castResult.Value;
                model.ClosingDateText = model.ClosingDate.HasValue ? model.ClosingDate.Value.ToShortDateString() : string.Empty;

                SetLocalization(model, true);

                return PartialView("_CreateEdit", model);
            }
            else
            {
                return null;
            }
        }

        [Authorize]
        [HttpPost("work/jobposition/save")]
        public IActionResult Save(JobPositionViewModel vm)
        {
            try
            {
                vm.UserId = CurrentUserId;

                if (!string.IsNullOrWhiteSpace(vm.ClosingDateText))
                {
                    vm.ClosingDate = DateTime.Parse(vm.ClosingDateText);
                }

                OperationResultVo<Guid> saveResult = jobPositionAppService.Save(CurrentUserId, vm);

                if (saveResult.Success)
                {
                    GenerateFeedPost(vm);

                    string url = Url.Action("Details", "JobPosition", new { area = "Work", id = vm.Id, pointsEarned = saveResult.PointsEarned });

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


        [HttpDelete("work/jobposition/deletejobposition/{jobPositionId:guid}")]
        public IActionResult DeleteJobPosition(Guid jobPositionId)
        {
            try
            {
                OperationResultVo serviceResult = jobPositionAppService.Remove(CurrentUserId, jobPositionId);


                OperationResultListVo<Application.ViewModels.Search.UserContentSearchViewModel> searchContentResult = userContentAppService.Search(CurrentUserId, jobPositionId.ToString());

                if (searchContentResult.Success && searchContentResult.Value.Any())
                {
                    Application.ViewModels.Search.UserContentSearchViewModel existing = searchContentResult.Value.FirstOrDefault();

                    if (existing != null)
                    {
                        userContentAppService.Remove(CurrentUserId, existing.ContentId);
                    }
                }


                string url = Url.Action("Index", "JobPosition", new { area = "Work" });

                return Json(new OperationResultRedirectVo(url, serviceResult.Message));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [HttpPost("work/jobposition/changestatus/{jobPositionId:guid}")]
        public IActionResult ChangeStatus(Guid jobPositionId, JobPositionStatus selectedStatus)
        {
            try
            {
                jobPositionAppService.ChangeStatus(CurrentUserId, jobPositionId, selectedStatus);

                string url = Url.Action("Index", "JobPosition", new { area = "Work" });

                return Json(new OperationResultRedirectVo(url));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [HttpPost("work/jobposition/apply/{jobPositionId:guid}")]
        public async Task<IActionResult> Apply(Guid jobPositionId, string coverLetter)
        {
            try
            {

                Infra.CrossCutting.Identity.Models.ApplicationUser user = await UserManager.GetUserAsync(User);

                OperationResultVo serviceResult = jobPositionAppService.Apply(CurrentUserId, jobPositionId, user.Email, coverLetter);

                if (serviceResult.Success)
                {
                    string url = Url.Action("Details", "JobPosition", new { area = "Work", id = jobPositionId });

                    OperationResultVo<Guid> result = serviceResult as OperationResultVo<Guid>;
                    Infra.CrossCutting.Identity.Models.ApplicationUser poster = await UserManager.FindByIdAsync(result.Value.ToString());

                    await NotificationSender.SendEmailApplicationAsync(poster.Email, user.Email, Url.JobPositionDetailsCallbackLink(jobPositionId.ToString(), Request.Scheme));

                    return Json(new OperationResultRedirectVo(url, SharedLocalizer[serviceResult.Message]));
                }
                else
                {
                    return Json(new OperationResultVo(SharedLocalizer[serviceResult.Message]));
                }


            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }

        [HttpPost("work/jobposition/rateapplicant/{jobPositionId:guid}/{userId:guid}")]
        public IActionResult RateApplicant(Guid jobPositionId, Guid userId, string score)
        {
            try
            {
                decimal scoreDecimal = decimal.Parse(score, CultureInfo.InvariantCulture);

                OperationResultVo serviceResult = jobPositionAppService.RateApplicant(CurrentUserId, jobPositionId, userId, scoreDecimal);

                return Json(new OperationResultVo(serviceResult.Success, serviceResult.Message));
            }
            catch (Exception ex)
            {
                return Json(new OperationResultVo(ex.Message));
            }
        }
        private void SetLocalization(JobPositionViewModel item)
        {
            SetLocalization(item, false);
        }

        private void SetLocalization(JobPositionViewModel item, bool editing)
        {
            if (item != null)
            {
                if (item.Remote || string.IsNullOrWhiteSpace(item.Location))
                {
                    item.Location = SharedLocalizer["Planet Earth"];
                }

                DisplayAttribute displayWorkType = item.WorkType.GetAttributeOfType<DisplayAttribute>();
                Microsoft.Extensions.Localization.LocalizedString localizedWorkType = SharedLocalizer[displayWorkType != null ? displayWorkType.Name : item.WorkType.ToString()];

                item.Title = SharedLocalizer["{0} at {1}", localizedWorkType, item.Location];


                DisplayAttribute displayStatus = item.Status.GetAttributeOfType<DisplayAttribute>();
                item.StatusLocalized = SharedLocalizer[displayStatus != null ? displayStatus.Name : item.WorkType.ToString()];

                if (item.Id != Guid.Empty && !editing && (!string.IsNullOrWhiteSpace(item.CompanyName) && item.CompanyName.Equals(JobPositionBenefit.NotInformed.ToDisplayName())) || string.IsNullOrWhiteSpace(item.CompanyName))
                {
                    item.CompanyName = SharedLocalizer[JobPositionBenefit.NotInformed.ToDisplayName()];
                }
            }
        }

        private void GenerateFeedPost(JobPositionViewModel vm)
        {
            if (vm != null && vm.Status == JobPositionStatus.OpenForApplication)
            {
                string json = JsonConvert.SerializeObject(vm);

                UserContentViewModel newContent = new UserContentViewModel
                {
                    UserId = CurrentUserId,
                    UserContentType = UserContentType.JobPosition,
                    Content = json,
                    Language = vm.Language
                };

                OperationResultListVo<Application.ViewModels.Search.UserContentSearchViewModel> searchContentResult = userContentAppService.Search(CurrentUserId, vm.Id.ToString());

                if (searchContentResult.Success && searchContentResult.Value.Any())
                {
                    Application.ViewModels.Search.UserContentSearchViewModel existing = searchContentResult.Value.FirstOrDefault();

                    if (existing != null)
                    {
                        newContent.Id = existing.ContentId;
                    }
                }

                userContentAppService.Save(CurrentUserId, newContent);
            }
        }
    }
}