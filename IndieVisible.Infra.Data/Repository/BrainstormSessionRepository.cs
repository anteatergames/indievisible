using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class BrainstormSessionRepository : Repository<BrainstormSession>, IBrainstormSessionRepository
    {
        public BrainstormSessionRepository(IndieVisibleContext context) : base(context)
        {
        }
    }
}
