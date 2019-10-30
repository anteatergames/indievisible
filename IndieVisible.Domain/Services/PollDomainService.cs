using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public class PollDomainService : BaseDomainMongoService<Poll, IPollRepository>, IPollDomainService
    {
        public PollDomainService(IPollRepository repository) : base(repository)
        {
        }

        public Poll GetByUserContentId(Guid id)
        {
            Poll obj = repository.Get(x => x.UserContentId == id).FirstOrDefault();

            return obj;
        }

        public PollOption GetOptionById(Guid id)
        {
            PollOption obj = repository.GetOptionById(id);

            return obj;
        }

        public Guid AddVote(Guid pollId, PollVote vote)
        {
            repository.AddVote(pollId, vote);

            return vote.Id;
        }


        public Guid UpdateVote(Guid pollId, PollVote vote)
        {
            repository.UpdateVote(vote);

            return vote.Id;
        }

        public bool CheckUserVoted(Guid userId, Guid pollOptionId)
        {
            int count = repository.CountVotes(x => x.UserId == userId && x.PollOptionId == pollOptionId);

            return count > 0;
        }

        public IEnumerable<PollVote> GetVotes(Guid userId, Guid pollId)
        {
            IQueryable<PollVote> objs = repository.GetVotes(pollId, x => x.UserId == userId);

            return objs.ToList();
        }

        public IEnumerable<PollVote> GetByPollId(Guid pollId)
        {
            IQueryable<PollVote> objs = repository.GetVotes(pollId);

            return objs.ToList();
        }

        public IEnumerable<PollVote> GetByPollOptionId(Guid pollOptionId)
        {
            IQueryable<PollVote> objs = repository.GetVotes(x => x.PollOptionId == pollOptionId);

            return objs.ToList();
        }
    }
}
