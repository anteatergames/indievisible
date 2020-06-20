using System;

namespace IndieVisible.Application.ViewModels.Study
{
    public class StudyGroupMemberViewModel : BaseViewModel
    {
        public Guid? PlanId { get; set; }

        public bool Accepted { get; set; }

        public decimal FinalScore { get; set; }

        public bool Passed { get; set; }

        public DateTime? ConclusionDate { get; set; }
    }
}
