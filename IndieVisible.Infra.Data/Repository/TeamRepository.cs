using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IndieVisible.Infra.Data.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(IndieVisibleContext context) : base(context)
        {
        }

        public override IQueryable<Team> GetAll()
        {
            return DbSet.Include(x => x.Members);
        }

        public override Team GetById(Guid id)
        {
            Team obj = DbSet.Include(x => x.Members).FirstOrDefault(x => x.Id == id);

            return obj;
        }
    }
}
