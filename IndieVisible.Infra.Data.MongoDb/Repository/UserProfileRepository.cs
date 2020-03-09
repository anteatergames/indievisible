using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Guid>> GetAllUserIds()
        {
            List<Guid> ids = await DbSet.AsQueryable().Select(x => x.UserId).ToListAsync();

            return ids;
        }

        public async Task<UserProfileEssentialVo> GetBasicDataByUserId(Guid targetUserId)
        {
            UserProfileEssentialVo profile = await DbSet.Find(x => x.UserId == targetUserId).Project(x => new UserProfileEssentialVo
            {
                Id = x.Id,
                UserId = targetUserId,
                Name = x.Name,
                Location = x.Location,
                CreateDate = x.CreateDate,
                HasCoverImage = x.HasCoverImage
            }).FirstOrDefaultAsync();

            return profile;
        }

        public async Task<bool> AddFollow(Guid followerUserId, Guid userId)
        {
            UserFollow model = new UserFollow
            {
                UserId = followerUserId
            };

            FilterDefinition<UserProfile> filter = Builders<UserProfile>.Filter.Where(x => x.UserId == userId);
            UpdateDefinition<UserProfile> add = Builders<UserProfile>.Update.AddToSet(c => c.Followers, model);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public Task<int> CountFollowers(Guid userId)
        {
            int count = DbSet.AsQueryable().SelectMany(x => x.Followers).Where(x => x.UserId == userId).Count();

            return Task.FromResult(count);
        }

        public Task<IQueryable<UserFollow>> GetFollows(Guid userId, Guid followerId)
        {
            IQueryable<UserFollow> list = DbSet.AsQueryable().Where(x => x.UserId == userId).SelectMany(x => x.Followers).Where(x => x.UserId == followerId).AsQueryable();

            return Task.FromResult(list);
        }

        public async Task<bool> RemoveFollower(Guid userId, Guid followUserId)
        {
            FilterDefinition<UserProfile> filter = Builders<UserProfile>.Filter.Where(x => x.UserId == followUserId);
            UpdateDefinition<UserProfile> remove = Builders<UserProfile>.Update.PullFilter(c => c.Followers, m => m.UserId == userId);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }
    }
}