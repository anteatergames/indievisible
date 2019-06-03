using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class UserConnection : Entity
    {
        public Guid TargetUserId { get; set; }

        public DateTime? ApprovalDate { get; set; }
    }
}
