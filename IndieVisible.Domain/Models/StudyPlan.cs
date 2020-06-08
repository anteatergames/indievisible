using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class StudyPlan : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal ScoreToPass { get; set; }

        public List<StudyActivity> Activities { get; set; }

        public StudyPlan()
        {
            Activities = new List<StudyActivity>();
        }
    }
}
