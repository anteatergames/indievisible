using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(IMongoContext context) : base(context)
        {
        }
        public async Task<UserProfileEssentialVo> GetBasicDataByUserId(Guid targetUserId)
        {
            var profile = await DbSet.Find(x => x.UserId == targetUserId).Project(x => new UserProfileEssentialVo
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

        public async Task<bool> AddFollow(UserFollow model)
        {
            var filter = Builders<UserProfile>.Filter.Where(x => x.UserId == model.FollowUserId);
            var add = Builders<UserProfile>.Update.AddToSet(c => c.Followers, model);

            var result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public Task<int> CountFollow(Expression<Func<UserFollow, bool>> where)
        {
            var count = DbSet.AsQueryable().SelectMany(x => x.Followers).Count(where);

            return Task.FromResult(count);
        }

        public Task<IQueryable<UserFollow>> GetFollows(Expression<Func<UserFollow, bool>> where)
        {
            var list = DbSet.AsQueryable().SelectMany(x => x.Followers).Where(where).AsQueryable();

            return Task.FromResult(list);
        }

        public async Task<bool> RemoveFollower(Guid userId, Guid followUserId)
        {
            var filter = Builders<UserProfile>.Filter.Where(x => x.UserId == followUserId);
            var remove = Builders<UserProfile>.Update.PullFilter(c => c.Followers, m => m.UserId == userId);

            var result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }
    }
}
