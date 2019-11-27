using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IPollDomainService : IDomainService<Poll>
    {
        Poll GetByUserContentId(Guid userContentId);

        Poll GetPollByOptionId(Guid id);

        void AddVote(Guid userId, Guid pollId, Guid optionId);

        void ReplaceVote(Guid userId, Guid pollId, Guid oldOptionId, Guid newOptionId);

        IEnumerable<PollVote> GetVotes(Guid pollId);

        void RemoveByContentId(Guid userContentId);
    }
}