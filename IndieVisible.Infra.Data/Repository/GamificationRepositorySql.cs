using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using System;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class GamificationRepositorySql : RepositorySql<Gamification>, IGamificationRepositorySql
    {
        public GamificationRepositorySql(IndieVisibleContext context) : base(context)
        {
        }

        public new Gamification GetByUserId(Guid userId)
        {
            return DbSet.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
