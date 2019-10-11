using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IndieVisibleContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(IndieVisibleContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetByUserId(Guid userId)
        {
            return DbSet.Where(x => x.UserId == userId);
        }

        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Count(where);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where(where);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where, string navigationPropertyToInclude)
        {
            return DbSet.Where(where).Include(navigationPropertyToInclude);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
