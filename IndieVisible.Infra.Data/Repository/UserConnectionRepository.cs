using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserConnectionRepository : Repository<UserConnection>, IUserConnectionRepositorySql
    {
        public UserConnectionRepository(IndieVisibleContext context) : base(context)
        {

        }
    }
}
