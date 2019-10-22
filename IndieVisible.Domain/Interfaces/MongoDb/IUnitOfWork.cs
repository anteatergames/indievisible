using System;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool HasPendingCommands { get; }

        Task<bool> Commit();
    }
}
