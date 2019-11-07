using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class PollVoteRepositorySql : RepositorySql<PollVote>, IPollVoteRepositorySql
    {
        public PollVoteRepositorySql(IndieVisibleContext context) : base(context)
        {
        }
    }
}
