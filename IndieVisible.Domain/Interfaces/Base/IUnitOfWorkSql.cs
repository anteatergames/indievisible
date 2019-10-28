using System;

namespace IndieVisible.Domain.Interfaces.Base
{
    public interface IUnitOfWorkSql : IDisposable
    {
        bool Commit();
        void Dispose();
    }
}
