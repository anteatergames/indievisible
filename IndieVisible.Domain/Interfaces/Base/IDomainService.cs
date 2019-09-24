using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Interfaces
{
    public interface IDomainService<T>
    {
        int Count();
        IEnumerable<T> GetAll();
        int Count(Expression<Func<T, bool>> where);
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        T GetById(Guid id);
        IEnumerable<T> GetByUserId(Guid userId);
        Guid Add(T model);
        Guid Update(T model);
        void Remove(Guid id);
    }
}
