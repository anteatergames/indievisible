using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class UserContentRepository : BaseRepository<UserContent>, IUserContentRepository
    {
        public UserContentRepository(IMongoContext context) : base(context)
        {
        }

        public override void Add(UserContent obj)
        {
            if (obj.Language == 0)
            {
                obj.Language = SupportedLanguage.English;
            }

            base.Add(obj);
        }

        public Task<int> CountComments(Expression<Func<UserContentComment, bool>> where)
        {
            var count = DbSet.AsQueryable().SelectMany(x => x.Comments).Where(where).Count();

            return Task.FromResult(count);
        }

        public Task<IQueryable<UserContentComment>> GetComments(Expression<Func<UserContentComment, bool>> where)
        {
            var list = DbSet.AsQueryable().SelectMany(x => x.Comments).Where(where).AsQueryable();

            return Task.FromResult(list);
        }

        public Task<IQueryable<UserContentLike>> GetLikes(Func<UserContentLike, bool> where)
        {
            var list = DbSet.AsQueryable().SelectMany(x => x.Likes).Where(where).AsQueryable();

            return Task.FromResult(list);
        }

        public async Task<bool> AddLike(UserContentLike model)
        {
            var filter = Builders<UserContent>.Filter.Where(x => x.Id == model.ContentId);
            var add = Builders<UserContent>.Update.AddToSet(c => c.Likes, model);

            var result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> RemoveLike(Guid userId, Guid userContentId)
        {
            var filter = Builders<UserContent>.Filter.Where(x => x.Id == userContentId);
            var remove = Builders<UserContent>.Update.PullFilter(c => c.Likes, m => m.UserId == userId);

            var result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> AddComment(UserContentComment model)
        {
            var filter = Builders<UserContent>.Filter.Where(x => x.Id == model.UserContentId);
            var add = Builders<UserContent>.Update.AddToSet(c => c.Comments, model);

            var result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }
    }
}
