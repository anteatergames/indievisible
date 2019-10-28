using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IGamificationLevelRepository : IRepositorySql<GamificationLevel>
    {
        GamificationLevel GetByNumber(int levelNumber);
    }
}
