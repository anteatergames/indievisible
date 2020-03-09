using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class GamificationLevelRepository : BaseRepository<GamificationLevel>, IGamificationLevelRepository
    {
        public GamificationLevelRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<GamificationLevel> GetByNumber(int levelNumber)
        {
            FilterDefinition<GamificationLevel> filter = Builders<GamificationLevel>.Filter.Eq(x => x.Number, levelNumber);

            GamificationLevel result = await DbSet.Find(filter).FirstOrDefaultAsync();

            return result;
        }
    }
}