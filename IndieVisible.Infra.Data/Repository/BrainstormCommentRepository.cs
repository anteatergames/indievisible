using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class BrainstormCommentRepository : Repository<BrainstormComment>, IBrainstormCommentRepository
    {
        public BrainstormCommentRepository(IndieVisibleContext context) : base(context)
        {

        }
    }
}
