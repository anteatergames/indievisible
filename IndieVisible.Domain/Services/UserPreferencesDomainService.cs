using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.Services
{
    public class UserPreferencesDomainService : BaseDomainMongoService<UserPreferences, IUserPreferencesRepository>, IUserPreferencesDomainService
    {
        public UserPreferencesDomainService(IUserPreferencesRepository repository) : base(repository)
        {
        }
    }
}