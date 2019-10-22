using System;

namespace IndieVisible.Domain.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        void Dispose();
    }
}
