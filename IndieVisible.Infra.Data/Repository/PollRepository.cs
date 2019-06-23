using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class PollRepository : Repository<Poll>, IPollRepository
    {
        public PollRepository(IndieVisibleContext context) : base(context)
        {
        }
    }
}
