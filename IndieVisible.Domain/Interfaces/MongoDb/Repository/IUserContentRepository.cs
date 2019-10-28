using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IUserContentRepository : IRepository<UserContent>
    {
        Task<int> CountComments(Expression<Func<UserContentComment, bool>> where);
        Task<IQueryable<UserContentComment>> GetComments(Expression<Func<UserContentComment, bool>> where);
    }
}
