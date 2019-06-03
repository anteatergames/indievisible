using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserBadgeRepository : Repository<UserBadge>, IUserBadgeRepository
    {
        public UserBadgeRepository(IndieVisibleContext context) : base(context)
        {
        }

        IEnumerable<UserBadge> IUserBadgeRepository.GetByUserId(Guid userId)
        {
            return DbSet.Where(x => x.UserId == userId);
        }
    }
}
