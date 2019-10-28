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
    }
}
