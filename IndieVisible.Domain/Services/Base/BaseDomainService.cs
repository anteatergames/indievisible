using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public abstract class BaseDomainService<T, TRepository> : IDomainService<T> where T: Entity where TRepository : class, IRepository<T>
    {
        protected readonly TRepository repository;

        protected BaseDomainService(TRepository repository)
        {
            this.repository = repository;
        }

        public Guid Add(T model)
        {
            this.repository.Add(model);

            return model.Id;
        }

        public int Count()
        {
            int count = this.repository.Count(x => true);

            return count;
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            var count = this.repository.Count(where);

            return count;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            var objs= this.repository.Get(where);

            return objs.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            var objs = this.repository.GetAll();

            return objs.ToList();
        }

        public T GetById(Guid id)
        {
            var obj = this.repository.GetById(id);

            return obj;
        }

        public IEnumerable<T> GetByUserId(Guid userId)
        {
            var obj = this.repository.Get(x => x.UserId == userId);

            return obj.ToList();
        }

        public void Remove(Guid id)
        {
            this.repository.Remove(id);
        }

        public Guid Update(T model)
        {
            this.repository.Update(model);

            return model.Id;
        }
    }
}
