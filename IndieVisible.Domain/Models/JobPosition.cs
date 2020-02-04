using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class JobPosition : Entity
    {
        public DateTime? ClosingDate { get; set; }

        public JobPositionStatus Status { get; set; }

        public JobPositionDuration Duration { get; set; }

        public JobPositonType PositionType { get; set; }

        public JobExperienceLevel ExperienceLevel { get; set; }

        public WorkType WorkType { get; set; }

        public bool Remote { get; set; }

        public string Location { get; set; }

        public decimal? Salary { get; set; }

        public DateTime? StartDate { get; set; }

        public PaymentFrequency PaymentFrequency { get; set; }

        public string Description { get; set; }

        public SupportedLanguage Language { get; set; }

        public List<JobApplicant> Applicants { get; set; }

        public JobPositionOrigin Origin { get; set; }

        public string Url { get; set; }

        public List<JobPositionBenefitVo> Benefits { get; set; }

        public JobPosition()
        {
            Applicants = new List<JobApplicant>();
            Benefits = new List<JobPositionBenefitVo>();
        }
    }
}