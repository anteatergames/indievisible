using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IGamificationActionRepository : IRepositorySql<GamificationAction>
    {
        GamificationAction GetByAction(PlatformAction action);
    }
}
