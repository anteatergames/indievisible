using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class UserContentRepository : Repository<UserContent>, IUserContentRepository
    {
        public UserContentRepository(IndieVisibleContext context) : base(context)
        {
        }

        public override IQueryable<UserContent> GetAll()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<UserContent, System.Collections.Generic.ICollection<UserContentLike>> data = Db.UserContents
                .Include(x => x.Likes); // TODO Doesn't work. Fix this

            return data;
        }
    }
}
