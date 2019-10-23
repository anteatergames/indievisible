using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Linq;
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
            var idea = await GetCollection<BrainstormIdea>().FindSync(x => x.Id == ideaId).FirstOrDefaultAsync();

            return idea;
        }

        public async Task<BrainstormVote> GetVote(Guid ideaId, Guid userId)
        {
            var filter = Builders<BrainstormSession>.Filter.ElemMatch(x => x.Ideas, x => x.Id == ideaId && x.Votes.Any(y => y.UserId == userId));

            var result = await DbSet.Find(filter).Project<BrainstormVote>(Builders<BrainstormSession>.Projection.Expression(x => x.Ideas[-1].Votes[-1])).SingleOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateIdea(BrainstormIdea idea)
        {

            var session = DbSet.Find(x => x.Id == idea.SessionId);

            var filter = Builders<BrainstormSession>.Filter.ElemMatch(x => x.Ideas, x => x.Id == idea.Id);

            var update = Builders<BrainstormSession>.Update.Combine(
                Builders<BrainstormSession>.Update.Set(x => x.Ideas[-1].Title, idea.Title),
                Builders<BrainstormSession>.Update.Set(x => x.Ideas[-1].Title, idea.Description)
                );

            var result = await DbSet.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
