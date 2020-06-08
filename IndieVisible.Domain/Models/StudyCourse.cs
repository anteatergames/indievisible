using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class StudyCourse : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SkillSet { get; set; }

        public bool OpenForApplication { get; set; }

        public string InvitationCode { get; set; }

        public decimal ScoreToPass { get; set; }

        public List<StudyGroupMember> Members { get; set; }

        public List<StudyGroup> Groups { get; set; }

        public List<StudyPlan> Plans { get; set; }

        public StudyCourse()
        {
            Members = new List<StudyGroupMember>();

            Groups = new List<StudyGroup>();

            Plans = new List<StudyPlan>();
        }
    }
}
