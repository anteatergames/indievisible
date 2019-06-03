using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class GamificationLevelRepository : Repository<GamificationLevel>, IGamificationLevelRepository
    {
        public GamificationLevelRepository(IndieVisibleContext context) : base(context)
        {
        }

        public GamificationLevel GetByNumber(int levelNumber)
        {
            return DbSet.FirstOrDefault(x => x.Number == levelNumber);
        }
    }
}
