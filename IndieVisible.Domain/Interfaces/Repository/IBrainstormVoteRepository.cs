using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;
using System;
using System.Linq;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IBrainstormVoteRepository : IRepository<BrainstormVote>
    {
        new IQueryable<BrainstormVote> GetAll();
        BrainstormVote Get(Guid votingItemId, Guid userId);
        IQueryable<BrainstormVote> GetByUserId(Guid userId);
    }
}
