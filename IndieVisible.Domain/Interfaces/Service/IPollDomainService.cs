using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IPollDomainService : IDomainService<Poll>
    {
        Poll GetByUserContentId(Guid id);

        Poll GetPollByOptionId(Guid id);

        void AddVote(Guid userId, Guid pollId, Guid optionId);

        void ReplaceVote(Guid userId, Guid pollId, Guid oldOptionId, Guid newOptionId);

        IEnumerable<PollVote> GetVotes(Guid pollId);
    }
}
