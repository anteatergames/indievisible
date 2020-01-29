using IndieVisible.Domain.Models;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using IndieVisible.Infra.Data.MongoDb.Interfaces;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class FeaturedContentRepository : BaseRepository<FeaturedContent>, IFeaturedContentRepository
    {
        public FeaturedContentRepository(IMongoContext context) : base(context)
        {
        }
    }
}