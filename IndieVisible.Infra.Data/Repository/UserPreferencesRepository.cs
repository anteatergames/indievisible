using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using System;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserPreferencesRepository : Repository<UserPreferences>, IUserPreferencesRepository
    {
        public UserPreferencesRepository(IndieVisibleContext context) : base(context)
        {

        }

        public new UserPreferences GetByUserId(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.UserId == id);
        }
    }
}
