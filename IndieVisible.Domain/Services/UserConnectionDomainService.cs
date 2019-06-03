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

        public IEnumerable<UserConnection> GetByTargetUserId(Guid targetUserId)
        {
            IQueryable<UserConnection> connnections = this.repository.Get(x => x.TargetUserId == targetUserId);

            return connnections.ToList();
        }

        public UserConnection Get(Guid currentUserId, Guid userId)
        {
            UserConnection existingConnection = this.repository.Get(x => x.UserId == currentUserId && x.TargetUserId == userId).FirstOrDefault();

            return existingConnection;
        }

        public bool CheckConnection(Guid currentUserId, Guid userId, bool accepted, bool bothWays)
        {
            var exists = this.repository.Get(x => x.UserId == currentUserId && x.TargetUserId == userId && x.ApprovalDate.HasValue == accepted).Any();

            if (bothWays)
            {
                var existsToMe = this.repository.Get(x => x.UserId == userId && x.TargetUserId == currentUserId && x.ApprovalDate.HasValue == accepted).Any();

                exists = exists || existsToMe;
            }

            return exists;
        }
    }
}
