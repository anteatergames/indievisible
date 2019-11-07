using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class BrainstormCommentRepositorySql : RepositorySql<BrainstormComment>, IBrainstormCommentRepositorySql
    {
        public BrainstormCommentRepositorySql(IndieVisibleContext context) : base(context)
        {

        }
    }
}
