using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IGamificationActionRepository : IRepository<GamificationAction>
    {
        Task<GamificationAction> GetByAction(PlatformAction action);
    }
}
