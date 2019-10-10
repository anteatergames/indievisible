using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class UserConnectionDomainService : BaseDomainService<UserConnection, IUserConnectionRepository>, IUserConnectionDomainService
    {
        public UserConnectionDomainService(IUserConnectionRepository repository) : base(repository)
        {
        }

        public IEnumerable<UserConnection> GetByTargetUserId(Guid targetUserId, bool approvedOnly)
        {
            IQueryable<UserConnection> connections = repository.Get(x => x.TargetUserId == targetUserId);

            if (approvedOnly)
            {
                connections = connections.Where(x => x.ApprovalDate.HasValue);
            }

            return connections.ToList();
        }

        public IEnumerable<UserConnection> GetByUserId(Guid userId, bool approvedOnly)
        {
            IQueryable<UserConnection> connections = repository.Get(x => x.UserId == userId);

            if (approvedOnly)
            {
                connections = connections.Where(x => x.ApprovalDate.HasValue);
            }

            return connections.ToList();
        }

        public UserConnection Get(Guid originalUserId, Guid connectedUserId)
        {
            UserConnection existingConnection = repository.Get(x => x.UserId == originalUserId && x.TargetUserId == connectedUserId).FirstOrDefault();

            return existingConnection;
        }

        public bool CheckConnection(Guid originalUserId, Guid connectedUserId, bool accepted, bool bothWays)
        {
            bool exists = repository.Get(x => x.UserId == originalUserId && x.TargetUserId == connectedUserId && x.ApprovalDate.HasValue == accepted).Any();

            if (bothWays)
            {
                bool existsToMe = repository.Get(x => x.UserId == connectedUserId && x.TargetUserId == originalUserId && x.ApprovalDate.HasValue == accepted).Any();

                exists = exists || existsToMe;
            }

            return exists;
        }
    }
}
