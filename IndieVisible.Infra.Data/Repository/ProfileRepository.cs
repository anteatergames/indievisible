using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class ProfileRepository : Repository<UserProfile>, IProfileRepository
    {
        public ProfileRepository(IndieVisibleContext context) : base(context)
        {

        }

        public IEnumerable<UserProfile> GetByUserId(Guid userId)
        {
            return DbSet.Where(x => x.UserId == userId);
        }
    }
}
