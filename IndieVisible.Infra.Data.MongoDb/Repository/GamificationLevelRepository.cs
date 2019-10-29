using System.Threading.Tasks;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class GamificationLevelRepository : BaseRepository<GamificationLevel>, IGamificationLevelRepository
    {
        public GamificationLevelRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<GamificationLevel> GetByNumber(int levelNumber)
        {
            var filter = Builders<GamificationLevel>.Filter.Eq(x => x.Number, levelNumber);

            var result = await DbSet.Find(filter).FirstOrDefaultAsync();

            return result;
        }
    }
}
