using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Team
{
    public class TeamViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Motto")]
        public string Motto { get; set; }

        [Display(Name = "Logo Url")]
        public string LogoUrl { get; set; }

        [Display(Name = "Recruiting")]
        public bool Recruiting { get; set; }

        [Display(Name = "Recruiting Before")]
        public bool RecruitingBefore { get; set; }

        [Display(Name = "Members")]
        public List<TeamMemberViewModel> Members { get; set; }

        [Display(Name = "Candidate")]
        public TeamMemberViewModel Candidate { get; set; }

        [Display(Name = "Current User Is Member")]
        public bool CurrentUserIsMember { get; set; }
    }
}