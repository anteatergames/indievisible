using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class BrainstormRepository : BaseRepository<BrainstormSession>, IBrainstormRepository
    {
        public BrainstormRepository(IMongoContext context) : base(context)
        {
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

        public async Task<bool> UpdateIdea(BrainstormIdea idea)
        {
            ReplaceOneResult result = await GetCollection<BrainstormIdea>().ReplaceOneAsync(x => x.Id == idea.Id, idea);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> AddVote(BrainstormVote model)
        {
            FilterDefinition<BrainstormIdea> filter = Builders<BrainstormIdea>.Filter.Where(x => x.Id == model.IdeaId);
            UpdateDefinition<BrainstormIdea> add = Builders<BrainstormIdea>.Update.AddToSet(c => c.Votes, model);

            UpdateResult result = await GetCollection<BrainstormIdea>().UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> UpdateVote(BrainstormVote model)
        {
            FilterDefinition<BrainstormIdea> filter = Builders<BrainstormIdea>.Filter.And(
                Builders<BrainstormIdea>.Filter.Eq(x => x.Id, model.IdeaId),
                Builders<BrainstormIdea>.Filter.ElemMatch(x => x.Votes, x => x.UserId == model.UserId));

            UpdateDefinition<BrainstormIdea> update = Builders<BrainstormIdea>.Update.Set(c => c.Votes[-1].VoteValue, model.VoteValue);

            UpdateResult result = await GetCollection<BrainstormIdea>().UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> AddComment(BrainstormComment model)
        {
            FilterDefinition<BrainstormIdea> filter = Builders<BrainstormIdea>.Filter.Where(x => x.Id == model.IdeaId);
            UpdateDefinition<BrainstormIdea> add = Builders<BrainstormIdea>.Update.AddToSet(c => c.Comments, model);

            UpdateResult result = await GetCollection<BrainstormIdea>().UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task AddIdea(BrainstormIdea model)
        {
            if (model.Status == 0)
            {
                model.Status = BrainstormIdeaStatus.Proposed;
            }

            await GetCollection<BrainstormIdea>().InsertOneAsync(model);
        }
    }
}