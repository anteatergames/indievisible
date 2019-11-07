using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class PollOptionRepositorySql : RepositorySql<PollOption>, IPollOptionRepositorySql
    {
        public PollOptionRepositorySql(IndieVisibleContext context) : base(context)
        {
        }
    }
}
