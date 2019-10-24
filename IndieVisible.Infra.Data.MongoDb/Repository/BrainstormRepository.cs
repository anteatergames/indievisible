using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class BrainstormRepository : BaseRepository<BrainstormSession>, IBrainstormRepository
    {
        public BrainstormRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<int> CountCommentsByIdea(Guid ideaId)
        {
            long count = await GetCollection<BrainstormComment>().CountDocumentsAsync(x => x.IdeaId == ideaId);

            return (int)count;
        }

        public async Task<int> CountVotesByIdea(Guid ideaId)
        {
            long count = await GetCollection<BrainstormVote>().CountDocumentsAsync(x => x.IdeaId == ideaId);

            return (int)count;
        }

        public async Task<IEnumerable<BrainstormComment>> GetCommentsByIdea(Guid ideaId)
        {
            List<BrainstormComment> comments = await GetCollection<BrainstormComment>().Find(x => x.IdeaId == ideaId).ToListAsync();

            return comments;
        }

        public async Task<IEnumerable<BrainstormComment>> GetCommentsBySession(Guid sessionId)
        {
            List<BrainstormComment> comments = await GetCollection<BrainstormComment>().Find(x => x.SessionId == sessionId).ToListAsync();

            return comments;
        }

        public async Task<BrainstormIdea> GetIdea(Guid ideaId)
        {
            BrainstormIdea idea = await GetCollection<BrainstormIdea>().FindSync(x => x.Id == ideaId).FirstOrDefaultAsync();

            return idea;
        }

        public async Task<IEnumerable<BrainstormIdea>> GetIdeasBySession(Guid sessionId)
        {
            List<BrainstormIdea> ideas = await GetCollection<BrainstormIdea>().Find(x => x.SessionId == sessionId).ToListAsync();

            return ideas;
        }

        public async Task<BrainstormVote> GetVote(Guid ideaId, Guid userId)
        {
            var result = await GetCollection<BrainstormVote>().Find(x => x.IdeaId == ideaId && x.UserId == userId).FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<BrainstormVote>> GetVotesBySession(Guid sessionId)
        {
            List<BrainstormVote> votes = await GetCollection<BrainstormVote>().Find(x => x.SessionId == sessionId).ToListAsync();

            return votes;
        }

        public async Task<int> SumVotesByIdea(Guid ideaId)
        {
            var votes = await GetCollection<BrainstormVote>().Find(x => x.IdeaId == ideaId).ToListAsync();

            var sum = votes.Sum(x => (int)x.VoteValue);

            return sum;
        }

        public async Task<bool> UpdateIdea(BrainstormIdea idea)
        {
            var result = await GetCollection<BrainstormIdea>().ReplaceOneAsync(x => x.Id == idea.Id, idea);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task AddVote(BrainstormVote model)
        {
            await GetCollection<BrainstormVote>().InsertOneAsync(model);
        }

        public async Task UpdateVote(BrainstormVote model)
        {
            await GetCollection<BrainstormVote>().ReplaceOneAsync<BrainstormVote>(x => x.Id == model.Id, model);
        }

        public async Task AddComment(BrainstormComment model)
        {
            await GetCollection<BrainstormComment>().InsertOneAsync(model);
        }

        public async Task AddIdea(BrainstormIdea model)
        {
            await GetCollection<BrainstormIdea>().InsertOneAsync(model);
        }
    }
}
