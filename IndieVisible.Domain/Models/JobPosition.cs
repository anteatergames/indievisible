using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class JobPosition : Entity
    {
        public WorkType WorkType { get; set; }

        public string Description { get; set; }

        public bool Remote { get; set; }

        public string Location { get; set; }

        public decimal Rate { get; set; }

        public PaymentFrequency PaymentFrequency { get; set; }

        public List<JobApplicant> Applicants { get; set; }
    }
}