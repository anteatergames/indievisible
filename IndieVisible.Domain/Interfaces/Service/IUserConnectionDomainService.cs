using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IUserConnectionDomainService : IDomainService<UserConnection>
    {
        IEnumerable<UserConnection> GetByTargetUserId(Guid targetUserId, bool approvedOnly);

        IEnumerable<UserConnection> GetByUserId(Guid userId, bool approvedOnly);

        UserConnection Get(Guid originalUserId, Guid connectedUserId);

        bool CheckConnection(Guid originalUserId, Guid connectedUserId, bool accepted, bool bothWays);
    }
}
