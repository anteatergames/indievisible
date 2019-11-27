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
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<bool> Follow(Guid userId, Guid gameId)
        {
            FilterDefinition<Game> gameFilter = Builders<Game>.Filter.Where(x => x.Id == gameId);
            UpdateDefinition<Game> followerRemove = Builders<Game>.Update.AddToSet(c => c.Followers, new GameFollow { UserId = userId, GameId = gameId });

            UpdateResult result = await DbSet.UpdateOneAsync(gameFilter, followerRemove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> Unfollow(Guid userId, Guid gameId)
        {
            FilterDefinition<Game> gameFilter = Builders<Game>.Filter.Where(x => x.Id == gameId);
            UpdateDefinition<Game> followerRemove = Builders<Game>.Update.PullFilter(c => c.Followers, m => m.UserId == userId);

            UpdateResult result = await DbSet.UpdateOneAsync(gameFilter, followerRemove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> Like(Guid userId, Guid gameId)
        {
            FilterDefinition<Game> gameFilter = Builders<Game>.Filter.Where(x => x.Id == gameId);
            UpdateDefinition<Game> followerRemove = Builders<Game>.Update.AddToSet(c => c.Likes, new GameLike { UserId = userId, GameId = gameId });

            UpdateResult result = await DbSet.UpdateOneAsync(gameFilter, followerRemove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> Unlike(Guid userId, Guid gameId)
        {
            FilterDefinition<Game> gameFilter = Builders<Game>.Filter.Where(x => x.Id == gameId);
            UpdateDefinition<Game> followerRemove = Builders<Game>.Update.PullFilter(c => c.Likes, m => m.UserId == userId);

            UpdateResult result = await DbSet.UpdateOneAsync(gameFilter, followerRemove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public Task<int> CountFollowers(Guid gameId)
        {
            int result = DbSet.AsQueryable().Where(x => x.Id == gameId).SelectMany(x => x.Followers).Count();

            return Task.FromResult(result);
        }

        public Task<int> CountLikes(Guid gameId)
        {
            int result = DbSet.AsQueryable().Where(x => x.Id == gameId).SelectMany(x => x.Likes).Count();

            return Task.FromResult(result);
        }
    }
}