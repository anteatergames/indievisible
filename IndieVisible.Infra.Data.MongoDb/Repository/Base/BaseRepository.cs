using IndieVisible.Domain.Core.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
        }

        public virtual void Add(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            ConfigDbSet();
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetByUserId(Guid id)
        {
            ConfigDbSet();

            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq(x => x.UserId, id));

            return data.ToList();
        }

        public virtual async Task<int> Count()
        {
            ConfigDbSet();
            var count = await DbSet.CountDocumentsAsync(Builders<TEntity>.Filter.Empty);
            return (int)count;
        }

        public virtual async Task<int> Count<T>(Expression<Func<TEntity, bool>> where)
        {
            ConfigDbSet();
            var count = await DbSet.CountDocumentsAsync(where);
            return (int)count;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            ConfigDbSet();

            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, obj.Id);

            Context.AddCommand(() => DbSet.ReplaceOneAsync(filter, obj));
        }

        public virtual void Remove(Guid id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> where)
        {
            ConfigDbSet();
            var result = DbSet.AsQueryable().Where(where);

            return Task.FromResult(result);
        }

        public IQueryable<TEntity> Get()
        {
            ConfigDbSet();
            var result = DbSet.AsQueryable();

            return result;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
