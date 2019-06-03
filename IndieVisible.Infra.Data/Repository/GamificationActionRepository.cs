using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class GamificationActionRepository : Repository<GamificationAction>, IGamificationActionRepository
    {
        public GamificationActionRepository(IndieVisibleContext context) : base(context)
        {
        }

        public GamificationAction GetByAction(PlatformAction action)
        {
            return DbSet.FirstOrDefault(x => x.Action == action);
        }
    }
}
