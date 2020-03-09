using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class UserBadgeRepository : BaseRepository<UserBadge>, IUserBadgeRepository
    {
        public UserBadgeRepository(IMongoContext context) : base(context)
        {
        }
    }
}