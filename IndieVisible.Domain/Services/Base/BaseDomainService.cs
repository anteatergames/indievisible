using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public abstract class BaseDomainService<T, TRepository> : IDomainService<T> where T : Entity where TRepository : class, IRepositorySql<T>
    {
        protected readonly TRepository repositorySql;

        protected BaseDomainService(TRepository repository)
        {
            this.repositorySql = repository;
        }

        public virtual Guid Add(T model)
        {
            repositorySql.Add(model);

            return model.Id;
        }

        public virtual int Count()
        {
            int count = repositorySql.Count(x => true);

            return count;
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            int count = repositorySql.Count(where);

            return count;
        }

        public virtual IEnumerable<T> Search(Expression<Func<T, bool>> where)
        {
            IQueryable<T> objs = repositorySql.Get(where);

            return objs.ToList();
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> objs = repositorySql.GetAll();

            return objs.ToList();
        }

        public virtual T GetById(Guid id)
        {
            T obj = repositorySql.GetById(id);

            return obj;
        }

        public virtual IEnumerable<T> GetByUserId(Guid userId)
        {
            IQueryable<T> obj = repositorySql.GetByUserId(userId);

            return obj.ToList();
        }

        public virtual void Remove(Guid id)
        {
            repositorySql.Remove(id);
        }

        public virtual Guid Update(T model)
        {
            repositorySql.Update(model);

            return model.Id;
        }

        IQueryable<T> IDomainService<T>.Search(Expression<Func<T, bool>> where)
        {
            return repositorySql.Get(where);
        }
    }
}
