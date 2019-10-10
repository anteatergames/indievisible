using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;

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

        public int Index { get; set; }

        public Dictionary<string, string> WorkDictionary { get; set; }
    }
}
