using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class FeaturedContentRepository : BaseRepository<FeaturedContent>, IFeaturedContentRepository
    {
        public FeaturedContentRepository(IMongoContext context) : base(context)
        {
        }
    }
}