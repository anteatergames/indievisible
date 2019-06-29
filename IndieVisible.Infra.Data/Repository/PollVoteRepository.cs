using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class PollVoteRepository : Repository<PollVote>, IPollVoteRepository
    {
        public PollVoteRepository(IndieVisibleContext context) : base(context)
        {
        }
    }
}
