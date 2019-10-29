using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserContentRepositorySql : Repository<UserContent>, IUserContentRepositorySql
    {
        public UserContentRepositorySql(IndieVisibleContext context) : base(context)
        {
        }

        public override IQueryable<UserContent> GetAll()
        {
            DbSet<UserContent> data = Db.UserContents;

            return data;
        }
    }
}
