using IndieVisible.Domain.Core.Models;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Motto { get; set; }

        public string LogoUrl { get; set; }


        public virtual ICollection<TeamMember> Members { get; set; }

    }
}
