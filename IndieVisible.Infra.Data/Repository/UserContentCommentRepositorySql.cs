using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserContentCommentRepositorySql : RepositorySql<UserContentComment>, IUserContentCommentRepositorySql
    {
        public UserContentCommentRepositorySql(IndieVisibleContext context) : base(context)
        {

        }
    }
}
