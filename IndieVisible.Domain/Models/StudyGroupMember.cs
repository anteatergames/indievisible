using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class StudyGroupMember : Entity
    {
        public Guid? PlanId { get; set; }

        public bool Accepted { get; set; }

        public decimal FinalScore { get; set; }

        public bool Passed { get; set; }

        public DateTime? ConclusionDate { get; set; }
    }
}
