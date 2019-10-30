using IndieVisible.Domain.Core.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
            ConfigDbSet();
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        protected IMongoCollection<Type> GetCollection<Type>()
        {
            return Context.GetCollection<Type>(typeof(Type).Name);
        }

        public virtual void Add(TEntity obj)
        {
            if (obj.CreateDate == DateTime.MinValue)
            {
                obj.CreateDate = DateTime.Now;
            }

            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetByUserId(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq(x => x.UserId, id));

            return data.ToList();
        }

        public virtual async Task<int> Count()
        {
            var count = await DbSet.CountDocumentsAsync(Builders<TEntity>.Filter.Empty);
            return (int)count;
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> where)
        {
            var count = await DbSet.CountDocumentsAsync(where);
            return (int)count;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, obj.Id);

            Context.AddCommand(() => DbSet.ReplaceOneAsync(filter, obj));
        }

        public virtual void Remove(Guid id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            var result = DbSet.AsQueryable().Where(where);

            return result;
        }

        public IQueryable<TEntity> Get()
        {
            var result = DbSet.AsQueryable();

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                Context?.Dispose();
            }
        }
    }
}
