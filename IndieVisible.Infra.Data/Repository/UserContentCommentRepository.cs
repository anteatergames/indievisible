using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserContentCommentRepository : Repository<UserContentComment>, IUserContentCommentRepositorySql
    {
        public UserContentCommentRepository(IndieVisibleContext context) : base(context)
        {

        }
    }
}
