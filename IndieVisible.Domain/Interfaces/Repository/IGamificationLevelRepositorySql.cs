using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IGamificationLevelRepositorySql : IRepositorySql<GamificationLevel>
    {
        GamificationLevel GetByNumber(int levelNumber);
    }
}
