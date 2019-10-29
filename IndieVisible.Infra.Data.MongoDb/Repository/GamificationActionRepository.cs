using System.Threading.Tasks;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class GamificationActionRepository : BaseRepository<GamificationAction>, IGamificationActionRepository
    {
        public GamificationActionRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<GamificationAction> GetByAction(PlatformAction action)
        {
            var filter = Builders<GamificationAction>.Filter.Eq(x => x.Action, action);

            var result = await DbSet.Find(filter).FirstOrDefaultAsync();

            return result;
        }
    }
}
