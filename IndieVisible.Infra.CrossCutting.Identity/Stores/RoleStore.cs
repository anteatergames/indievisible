using IndieVisible.Infra.CrossCutting.Identity.Model;
using IndieVisible.Infra.Data.MongoDb;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IndieVisible.Infra.CrossCutting.Identity.Stores
{
    public class RoleStore<TRole> : IQueryableRoleStore<TRole> where TRole : Role
    {
        private readonly IMongoCollection<TRole> _collection;

        public RoleStore(IMongoCollection<TRole> collection)
        {
            _collection = collection;
        }

        IQueryable<TRole> IQueryableRoleStore<TRole>.Roles
        {
            get
            {
                Task<System.Collections.Generic.List<TRole>> task = _collection.All();
                Task.WaitAny(task);
                return task.Result.AsQueryable();
            }
        }

        async Task<IdentityResult> IRoleStore<TRole>.CreateAsync(TRole role, CancellationToken cancellationToken)
        {
            TRole found = await _collection.FirstOrDefaultAsync(x => x.NormalizedName == role.NormalizedName);
            if (found == null) await _collection.InsertOneAsync(role, new InsertOneOptions(), cancellationToken);
            return IdentityResult.Success;
        }

        async Task<IdentityResult> IRoleStore<TRole>.UpdateAsync(TRole role, CancellationToken cancellationToken)
        {
            await _collection.ReplaceOneAsync(x => x.Id == role.Id, role, cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }

        async Task<IdentityResult> IRoleStore<TRole>.DeleteAsync(TRole role, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(x => x.Id == role.Id, cancellationToken);
            return IdentityResult.Success;
        }

        async Task<string> IRoleStore<TRole>.GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.Id);
        }

        async Task<string> IRoleStore<TRole>.GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            return (await _collection.FirstOrDefaultAsync(x => x.Id == role.Id))?.Name ?? role.Name;
        }

        async Task IRoleStore<TRole>.SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            await _collection.UpdateOneAsync(x => x.Id == role.Id, Builders<TRole>.Update.Set(x => x.Name, roleName), cancellationToken: cancellationToken);
        }

        async Task<string> IRoleStore<TRole>.GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.NormalizedName);
        }

        async Task IRoleStore<TRole>.SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            await _collection.UpdateOneAsync(x => x.Id == role.Id, Builders<TRole>.Update.Set(x => x.NormalizedName, normalizedName), cancellationToken: cancellationToken);
        }

        Task<TRole> IRoleStore<TRole>.FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return _collection.FirstOrDefaultAsync(x => x.Id == roleId);
        }

        Task<TRole> IRoleStore<TRole>.FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return _collection.FirstOrDefaultAsync(x => x.NormalizedName == normalizedRoleName);
        }

        protected virtual void Dispose(bool dispose)
        {
            // Nothing to dispose
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}