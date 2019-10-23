using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IBrainstormRepository : IRepositorySql<BrainstormSession>
    {
        Task<BrainstormIdea> GetIdea(Guid ideaId);
        Task<bool> UpdateIdea(BrainstormIdea idea);
        Task<BrainstormVote> GetVote(Guid ideaId, Guid userId);
    }
}
