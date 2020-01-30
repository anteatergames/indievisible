using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Jobs
{
    public class JobPositionViewModel : UserGeneratedBaseViewModel
    {
        public JobPositionStatus Status { get; set; }

        public WorkType WorkType { get; set; }

        public string Description { get; set; }

        public bool Remote { get; set; }

        public string Location { get; set; }

        public decimal? Rate { get; set; }

        public PaymentFrequency PaymentFrequency { get; set; }

        public List<JobApplicantViewModel> Applicants { get; set; }

        public bool CurrentUserApplied { get; set; }

        public int ApplicantCount { get; set; }

        public string Title { get; set; }
        public string StatusLocalized { get; set; }
    }
}
