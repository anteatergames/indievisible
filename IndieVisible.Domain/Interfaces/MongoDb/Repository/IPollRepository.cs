using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IPollRepository : IRepository<Poll>
    {
        PollOption GetOptionById(Guid id);
        void AddVote(Guid pollId, PollVote vote);
        void UpdateVote(PollVote vote);
        int CountVotes(Func<PollVote, bool> where);
        IQueryable<PollVote> GetVotes(Guid pollId, Func<PollVote, bool> where);
        IQueryable<PollVote> GetVotes(Guid pollId);
        IQueryable<PollVote> GetVotes(Func<PollVote, bool> where);
    }
}
