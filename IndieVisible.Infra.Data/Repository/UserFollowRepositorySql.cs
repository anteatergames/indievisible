using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserFollowRepositorySql : Repository<UserFollow>, IUserFollowRepositorySql
    {
        public UserFollowRepositorySql(IndieVisibleContext context) : base(context)
        {
        }
    }
}
