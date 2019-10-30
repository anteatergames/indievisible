using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class PollOptionRepositorySql : Repository<PollOption>, IPollOptionRepositorySql
    {
        public PollOptionRepositorySql(IndieVisibleContext context) : base(context)
        {
        }
    }
}
