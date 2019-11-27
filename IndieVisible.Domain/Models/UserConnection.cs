using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class UserConnection : Entity
    {
        public Guid TargetUserId { get; set; }

        public DateTime? ApprovalDate { get; set; }
    }
}