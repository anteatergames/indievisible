using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public abstract class BaseDomainMongoService<T, TRepository> : IDomainService<T> where T : Entity where TRepository : class, IRepository<T>
    {
        protected readonly TRepository repository;

        protected BaseDomainMongoService(TRepository repository)
        {
            this.repository = repository;
        }

        public virtual Guid Add(T model)
        {
            repository.Add(model);

            return model.Id;
        }

        public virtual int Count()
        {
            System.Threading.Tasks.Task<int> count = repository.Count();

            count.Wait();

            return count.Result;
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            int count = repository.Count(where).Result;

            return count;
        }

        public virtual IEnumerable<T> Search(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objs = repository.Get(where);

            return objs;
        }

        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> objs = repository.GetAll().Result;

            return objs.ToList();
        }

        public virtual IEnumerable<Guid> GetAllIds()
        {
            IEnumerable<Guid> objs = repository.Get().Select(x => x.Id);

            return objs.ToList();
        }

        public virtual T GetById(Guid id)
        {
            T obj = repository.GetById(id).Result;

            return obj;
        }

        public virtual IEnumerable<T> GetByUserId(Guid userId)
        {
            IEnumerable<T> obj = repository.GetByUserId(userId).Result;

            return obj.ToList();
        }

        public virtual void Remove(Guid id)
        {
            repository.Remove(id);
        }

        public virtual Guid Update(T model)
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