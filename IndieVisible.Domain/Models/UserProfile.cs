using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class UserProfile : Entity
    {
        public ProfileType Type { get; set; }

        public string Name { get; set; }

        public string Motto { get; set; }

        public string Bio { get; set; }

        public string StudioName { get; set; }

        public string Location { get; set; }

        public virtual ICollection<UserProfileExternalLink> ExternalLinks { get; set; }
        public virtual ICollection<UserFollow> Followers { get; set; }
    }
}
