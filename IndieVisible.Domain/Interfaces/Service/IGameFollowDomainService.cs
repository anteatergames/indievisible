using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IGameFollowDomainService : IDomainService<GameFollow>
    {
        int Count(Expression<Func<GameFollow, bool>> where);
        IEnumerable<GameFollow> GetByGameId(Guid gameId);
    }
}
