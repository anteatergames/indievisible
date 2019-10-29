using IndieVisible.Domain.Models;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IGamificationLevelRepository : IRepository<GamificationLevel>
    {
        Task<GamificationLevel> GetByNumber(int levelNumber);
    }
}
