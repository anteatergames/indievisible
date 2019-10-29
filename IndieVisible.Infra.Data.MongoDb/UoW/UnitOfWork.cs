using IndieVisible.Infra.Data.MongoDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public bool HasPendingCommands => _context.HasPendingCommands;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            if (!HasPendingCommands)
            {
                return false;
            }

            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
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
