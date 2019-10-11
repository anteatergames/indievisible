using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserBadgeRepository : Repository<UserBadge>, IUserBadgeRepository
    {
        public UserBadgeRepository(IndieVisibleContext context) : base(context)
        {
        }
    }
}
