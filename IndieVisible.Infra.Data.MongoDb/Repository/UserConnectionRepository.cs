using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class UserConnectionRepository : BaseRepository<UserConnection>, IUserConnectionRepository
    {
        public UserConnectionRepository(IMongoContext context) : base(context)
        {
        }
    }
}
