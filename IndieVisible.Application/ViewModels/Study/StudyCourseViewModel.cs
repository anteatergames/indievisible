using IndieVisible.Domain.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Study
{
    public class StudyCourseViewModel : UserGeneratedBaseViewModel
    {
        [Required(ErrorMessage = "A course need a name!")]
        [Display(Name = "Name", Description = "Choose a name for your course like:<ul><li>3D Modelling</li><li>Game Design for beginners</li><li>How to become a concept artist</li></ul>")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must describe your course.")]
        [Display(Name = "Description", Description = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The course must offer at least one skill.")]
        [Display(Name = "Skill Set", Description = "Choose here what type of skills the student will acquire with this course.")]
        public List<WorkType> SkillSet { get; set; }

        [Display(Name = "Open for Application")]
        public bool OpenForApplication { get; set; }

        [Display(Name = "Invitation Code")]
        public string InvitationCode { get; set; }

        [Display(Name = "Score to Pass")]
        public decimal ScoreToPass { get; set; }

        public List<StudyGroupMemberViewModel> Members { get; set; }

        public List<StudyGroupViewModel> Groups { get; set; }

        public List<StudyPlanViewModel> Plans { get; set; }

        public StudyCourseViewModel()
        {
            Members = new List<StudyGroupMemberViewModel>();

            Groups = new List<StudyGroupViewModel>();

            Plans = new List<StudyPlanViewModel>();
        }
    }
}
