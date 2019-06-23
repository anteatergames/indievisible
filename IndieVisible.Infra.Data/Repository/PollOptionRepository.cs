using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class PollOptionRepository : Repository<PollOption>, IPollOptionRepository
    {
        public PollOptionRepository(IndieVisibleContext context) : base(context)
        {
        }
    }
}
