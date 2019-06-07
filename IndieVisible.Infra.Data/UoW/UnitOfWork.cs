using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Infra.Data.Context;
using System;

namespace IndieVisible.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IndieVisibleContext _context;

        public UnitOfWork(IndieVisibleContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}