using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class GamificationActionRepository : BaseRepository<GamificationAction>, IGamificationActionRepository
    {
        public GamificationActionRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<GamificationAction> GetByAction(PlatformAction action)
        {
            FilterDefinition<GamificationAction> filter = Builders<GamificationAction>.Filter.Eq(x => x.Action, action);

            GamificationAction result = await DbSet.Find(filter).FirstOrDefaultAsync();

            return result;
        }
    }
}