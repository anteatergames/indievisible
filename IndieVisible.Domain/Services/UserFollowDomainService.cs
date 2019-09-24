using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.Services
{
    public class UserFollowDomainService : BaseDomainService<UserFollow, IUserFollowRepository>, IUserFollowDomainService
    {
        public UserFollowDomainService(IUserFollowRepository repository) : base(repository)
        {
        }
    }
}
