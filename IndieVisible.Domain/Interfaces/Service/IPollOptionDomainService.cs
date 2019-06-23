using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IPollOptionDomainService : IDomainService<PollOption>
    {
        IEnumerable<PollOption> GetByPollId(Guid pollId);
    }
}
