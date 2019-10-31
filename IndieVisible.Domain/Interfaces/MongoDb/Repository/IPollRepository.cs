using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IPollRepository : IRepository<Poll>
    {
        Poll GetPollByOptionId(Guid optionId);
        void AddVote(Guid pollId, PollVote vote);
        void RemoveVote(Guid userId, Guid optionId);
        int CountVotes(Func<PollVote, bool> where);
        IQueryable<PollVote> GetVotes(Guid pollId);
        void RemoveByContentId(Guid contentId);
    }
}
