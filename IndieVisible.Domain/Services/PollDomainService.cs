using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public class PollDomainService : BaseDomainService<Poll, IPollRepository>, IPollDomainService
    {
        private readonly IPollOptionRepository pollOptionRepository;
        private readonly IPollVoteRepository pollVoteRepository;

        public PollDomainService(IPollRepository repository, IPollOptionRepository pollOptionRepository, IPollVoteRepository pollVoteRepository) : base(repository)
        {
            this.pollOptionRepository = pollOptionRepository;
            this.pollVoteRepository = pollVoteRepository;
        }

        public Poll GetByUserContentId(Guid id)
        {
            Poll obj = repositorySql.Get(x => x.UserContentId == id).FirstOrDefault();

            return obj;
        }

        public IEnumerable<PollOption> GetOptionsByPollId(Guid pollId)
        {
            IQueryable<PollOption> objs = pollOptionRepository.Get(x => x.PollId == pollId);

            return objs.ToList();
        }

        public PollOption GetOptionById(Guid id)
        {
            PollOption obj = pollOptionRepository.GetById(id);

            return obj;
        }

        public int CountVotes(Expression<Func<PollVote, bool>> where)
        {
            int count = pollVoteRepository.Count(where);

            return count;
        }

        public Guid AddVote(PollVote model)
        {
            pollVoteRepository.Add(model);

            return model.Id;
        }


        public Guid UpdateVote(PollVote model)
        {
            pollVoteRepository.Update(model);

            return model.Id;
        }

        public bool CheckUserVoted(Guid userId, Guid pollOptionId)
        {
            int count = pollVoteRepository.Count(x => x.UserId == userId && x.PollOptionId == pollOptionId);

            return count > 0;
        }

        public IEnumerable<PollVote> GetVotes(Guid userId, Guid pollId)
        {
            IQueryable<PollVote> objs = pollVoteRepository.Get(x => x.UserId == userId && x.PollId == pollId);

            return objs.ToList();
        }

        public IEnumerable<PollVote> GetByPollId(Guid pollId)
        {
            IQueryable<PollVote> objs = pollVoteRepository.Get(x => x.PollId == pollId);

            return objs.ToList();
        }

        public IEnumerable<PollVote> GetByPollOptionId(Guid pollOptionId)
        {
            IQueryable<PollVote> objs = pollVoteRepository.Get(x => x.PollOptionId == pollOptionId);

            return objs.ToList();
        }
    }
}
