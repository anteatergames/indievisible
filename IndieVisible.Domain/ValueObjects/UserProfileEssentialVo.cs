using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class UserProfileEssentialVo : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool HasCoverImage { get; set; }
    }
}
