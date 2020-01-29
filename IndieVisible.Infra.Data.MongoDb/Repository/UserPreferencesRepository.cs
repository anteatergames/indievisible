using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class UserPreferencesRepository : BaseRepository<UserPreferences>, IUserPreferencesRepository
    {
        public UserPreferencesRepository(IMongoContext context) : base(context)
        {
        }
    }
}