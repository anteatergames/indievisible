using System;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Interfaces.Base
{
    public interface IRepositorySql<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetByUserId(Guid userId);
        int Count(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where, string navigationPropertyToInclude);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
