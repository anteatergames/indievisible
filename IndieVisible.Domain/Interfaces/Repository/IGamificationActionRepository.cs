using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IGamificationActionRepository : IRepository<GamificationAction>
    {
        GamificationAction GetByAction(PlatformAction action);
    }
}
