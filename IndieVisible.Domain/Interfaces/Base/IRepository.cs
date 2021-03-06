﻿using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);

        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetByUserId(Guid id);

        Task<int> Count();

        Task<int> Count(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> Get();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where);

        Task<IEnumerable<TEntity>> GetAll();

        void Update(TEntity obj);

        void Remove(Guid id);
    }
}