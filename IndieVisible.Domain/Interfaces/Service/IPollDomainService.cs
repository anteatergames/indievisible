using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IPollDomainService : IDomainService<Poll>
    {
        Poll GetByUserContentId(Guid id);

        PollOption GetOptionById(Guid id);

        Guid AddVote(Guid pollId, PollVote vote);

        Guid UpdateVote(Guid pollId, PollVote vote);

        IEnumerable<PollVote> GetByPollId(Guid pollId);

        IEnumerable<PollVote> GetByPollOptionId(Guid pollOptionId);

        IEnumerable<PollVote> GetVotes(Guid userId, Guid pollId);

        bool CheckUserVoted(Guid userId, Guid pollOptionId);
    }
}
