using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
