using IndieVisible.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IPollRepository : IRepository<Poll>
    {
        Poll GetPollByOptionId(Guid optionId);

        Task<bool> AddVote(Guid pollId, PollVote vote);

        Task<bool> RemoveVote(Guid userId, Guid pollId);

        Task<bool> UpdateVote(PollVote vote);

        int CountVotes(Func<PollVote, bool> where);

        IQueryable<PollVote> GetVotes(Guid pollId);

        void RemoveByContentId(Guid contentId);

        PollVote GetVote(Guid userId, Guid pollId);
    }
}