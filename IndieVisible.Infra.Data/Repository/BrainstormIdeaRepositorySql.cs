using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class BrainstormIdeaRepositorySql : RepositorySql<BrainstormIdea>, IBrainstormIdeaRepositorySql
    {
        public BrainstormIdeaRepositorySql(IndieVisibleContext context) : base(context)
        {
        }

        public override IQueryable<BrainstormIdea> GetAll()
        {
            DbSet<BrainstormIdea> data = Db.BrainstormIdeas;

            return data;
        }
    }
}
