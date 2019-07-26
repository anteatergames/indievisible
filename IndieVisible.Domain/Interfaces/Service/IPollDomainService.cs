using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IPollDomainService : IDomainService<Poll>
    {
        Poll GetByUserContentId(Guid id);

        IEnumerable<PollOption> GetOptionsByPollId(Guid pollId);

        PollOption GetOptionById(Guid id);
    }
}
