using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class UserFollow : Entity
    {
        public Guid FollowUserId { get; set; }
    }
}
