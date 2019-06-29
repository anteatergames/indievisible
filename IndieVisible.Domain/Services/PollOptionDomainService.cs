using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public class PollOptionDomainService : BaseDomainService<PollOption, IPollOptionRepository>, IPollOptionDomainService
    {
        public PollOptionDomainService(IPollOptionRepository repository) : base(repository)
        {
        }

        public IEnumerable<PollOption> GetByPollId(Guid pollId)
        {
            var objs = repository.Get(x => x.PollId == pollId);

            return objs.ToList();
        }
    }
}
