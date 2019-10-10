using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Team
{
    public class TeamViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Motto { get; set; }

        public string LogoUrl { get; set; }


        public List<TeamMemberViewModel> Members { get; set; }
    }
}
