using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IBrainstormRepository : IRepository<BrainstormSession>
    {
        Task<BrainstormIdea> GetIdea(Guid ideaId);
        Task AddIdea(BrainstormIdea model);
        Task<bool> UpdateIdea(BrainstormIdea idea);
        Task<BrainstormVote> GetVote(Guid ideaId, Guid userId);
        Task<IEnumerable<BrainstormIdea>> GetIdeasBySession(Guid sessionId);
        Task<IEnumerable<BrainstormVote>> GetVotesBySession(Guid sessionId);
        Task<IEnumerable<BrainstormComment>> GetCommentsBySession(Guid sessionId);
        Task<int> CountVotesByIdea(Guid ideaId);
        Task<int> SumVotesByIdea(Guid ideaId);
        Task<int> CountCommentsByIdea(Guid ideaId);
        Task<IEnumerable<BrainstormComment>> GetCommentsByIdea(Guid ideaId);
        Task AddVote(BrainstormVote model);
        Task UpdateVote(BrainstormVote model);
        Task AddComment(BrainstormComment model);
    }
}
