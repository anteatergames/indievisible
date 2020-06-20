using IndieVisible.Domain.Core.Models;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class StudyPlan : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal ScoreToPass { get; set; }

        public int Order { get; set; }

        public List<StudyActivity> Activities { get; set; }

        public StudyPlan()
        {
            Activities = new List<StudyActivity>();
        }
    }
}
