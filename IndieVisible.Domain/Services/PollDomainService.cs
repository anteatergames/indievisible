using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class PollDomainService : BaseDomainService<Poll, IPollRepository>, IPollDomainService
    {
        private readonly IPollOptionRepository pollOptionRepository;

        public PollDomainService(IPollRepository repository, IPollOptionRepository pollOptionRepository) : base(repository)
        {
            this.pollOptionRepository = pollOptionRepository;
        }

        public Poll GetByUserContentId(Guid id)
        {
            var obj = this.repository.Get(x => x.UserContentId == id).FirstOrDefault();

            return obj;
        }

        public IEnumerable<PollOption> GetOptionsByPollId(Guid pollId)
        {
            var objs = pollOptionRepository.Get(x => x.PollId == pollId);

            return objs.ToList();
        }

        public PollOption GetOptionById(Guid id)
        {
            var obj = pollOptionRepository.GetById(id);

            return obj;
        }
    }
}
