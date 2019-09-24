using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class PollVoteDomainService : BaseDomainService<PollVote, IPollVoteRepository>, IPollVoteDomainService
    {
        public PollVoteDomainService(IPollVoteRepository repository) : base(repository)
        {
        }

        public bool CheckUserVoted(Guid userId, Guid pollOptionId)
        {
            var count = repository.Count(x => x.UserId == userId && x.PollOptionId == pollOptionId);

            return count > 0;
        }

        public IEnumerable<PollVote> Get(Guid userId, Guid pollId)
        {
            var objs = repository.Get(x => x.UserId == userId && x.PollId == pollId);

            return objs.ToList();
        }

        public IEnumerable<PollVote> GetByPollId(Guid pollId)
        {
            var objs = repository.Get(x => x.PollId == pollId);

            return objs.ToList();
        }

        public IEnumerable<PollVote> GetByPollOptionId(Guid pollOptionId)
        {
            var objs = repository.Get(x => x.PollOptionId == pollOptionId);

            return objs.ToList();
        }
    }
}
