using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetByUserId(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
