using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IGameFollowDomainService : IDomainService<GameFollow>
    {
        IEnumerable<GameFollow> GetByGameId(Guid gameId);
    }
}
