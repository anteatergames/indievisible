using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.ViewModels.Study
{
    public class StudyGroupViewModel
    {
        public Guid? DefaultPlanId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SupportedLanguage Language { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal ScoreToPass { get; set; }
    }
}
