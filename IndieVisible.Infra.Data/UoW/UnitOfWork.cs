using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Infra.Data.Context;

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

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}