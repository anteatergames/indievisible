﻿using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndieVisible.Application.ViewModels.Jobs
{
    public class JobPositionViewModel : UserGeneratedBaseViewModel
    {
        #region Entity Properties
        public DateTime? ClosingDate { get; set; }

        [Display(Name = "Status")]
        public JobPositionStatus Status { get; set; }

        [Display(Name = "Position Type")]
        public JobPositonType PositionType { get; set; }

        [Display(Name = "Experience Level")]
        public JobExperienceLevel ExperienceLevel { get; set; }

        [Display(Name = "Work Type")]
        public WorkType WorkType { get; set; }

        [Display(Name = "Remote")]
        public bool Remote { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Salary")]
        public decimal? Salary { get; set; }

        [Display(Name = "Payment Frequency")]
        public PaymentFrequency PaymentFrequency { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Language")]
        public SupportedLanguage Language { get; set; }

        public List<JobApplicantViewModel> Applicants { get; set; }
        #endregion

        [Display(Name = "Current User Applied")]
        public bool CurrentUserApplied { get; set; }

        [Display(Name = "Applicant Count")]
        public int ApplicantCount { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Status")]
        public string StatusLocalized { get; set; }

        [Display(Name = "Closing Date")]
        public string ClosingDateText { get; set; }
    }
}