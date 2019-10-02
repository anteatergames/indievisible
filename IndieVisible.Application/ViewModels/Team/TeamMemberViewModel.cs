using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Application.ViewModels.Team
{
    public class TeamMemberViewModel : BaseViewModel
    {
        public bool Leader { get; set; }

        public InvitationStatus InvitationStatus { get; set; }

        public string Name { get; set; }

        public List<TeamWorkType> Works { get; set; }

        public string Role { get; set; }

        public string Quote { get; set; }

        public Guid TeamId { get; set; }

        public string ProfileImage { get; set; }

        public string WorksText
        {
            get
            {
                return (Works == null || !Works.Any()) ? string.Empty : String.Join(", ", Works);
            }
        }

        public int Index { get; set; }
    }
}
