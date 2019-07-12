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
        public PollDomainService(IPollRepository repository) : base(repository)
        {
        }

        public Poll GetByUserContentId(Guid id)
        {
            var obj = this.repository.Get(x => x.UserContentId == id).FirstOrDefault();

            return obj;
        }
    }
}
