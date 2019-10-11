using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public abstract class BaseDomainService<T, TRepository> : IDomainService<T> where T : Entity where TRepository : class, IRepository<T>
    {
        protected readonly TRepository repository;

        protected BaseDomainService(TRepository repository)
        {
            this.repository = repository;
        }

        public Guid Add(T model)
        {
            repository.Add(model);

            return model.Id;
        }

        public int Count()
        {
            int count = repository.Count(x => true);

            return count;
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            int count = repository.Count(where);

            return count;
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> where)
        {
            IQueryable<T> objs = repository.Get(where);

            return objs.ToList();
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> objs = repository.GetAll();

            return objs.ToList();
        }

        public T GetById(Guid id)
        {
            T obj = repository.GetById(id);

            return obj;
        }

        public IEnumerable<T> GetByUserId(Guid userId)
        {
            IQueryable<T> obj = repository.GetByUserId(userId);

            return obj.ToList();
        }

        public void Remove(Guid id)
        {
            repository.Remove(id);
        }

        public Guid Update(T model)
        {
            repository.Update(model);

            return model.Id;
        }

        IQueryable<T> IDomainService<T>.Search(Expression<Func<T, bool>> where)
        {
            return repository.Get(where);
        }
    }
}
