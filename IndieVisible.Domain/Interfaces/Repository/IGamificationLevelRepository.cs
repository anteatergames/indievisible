using IndieVisible.Domain.Models;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IGamificationLevelRepository : IRepository<GamificationLevel>
    {
        Task<GamificationLevel> GetByNumber(int levelNumber);
    }
}