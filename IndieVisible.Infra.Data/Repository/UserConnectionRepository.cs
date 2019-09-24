using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserConnectionRepository : Repository<UserConnection>, IUserConnectionRepository
    {
        public UserConnectionRepository(IndieVisibleContext context) : base(context)
        {

        }
    }
}
