using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IPollVoteDomainService : IDomainService<PollVote>
    {
        IEnumerable<PollVote> GetByPollId(Guid pollId);

        IEnumerable<PollVote> GetByPollOptionId(Guid pollOptionId);

        IEnumerable<PollVote> Get(Guid userId, Guid pollId);

        bool CheckUserVoted(Guid userId, Guid pollOptionId);
    }
}
