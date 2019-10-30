using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserFollowRepository : Repository<UserFollow>, IUserFollowRepositorySql
    {
        public UserFollowRepository(IndieVisibleContext context) : base(context)
        {
        }
    }
}
