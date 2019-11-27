using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class UserFollow : Entity
    {
        public Guid? FollowUserId { get; set; }
    }
}