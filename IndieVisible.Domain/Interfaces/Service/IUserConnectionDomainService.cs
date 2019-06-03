using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IUserConnectionDomainService : IDomainService<UserConnection>
    {
        IEnumerable<UserConnection> GetByTargetUserId(Guid targetUserId);
        UserConnection Get(Guid currentUserId, Guid userId);
        bool CheckConnection(Guid currentUserId, Guid userId, bool accepted, bool bothWays);
    }
}
