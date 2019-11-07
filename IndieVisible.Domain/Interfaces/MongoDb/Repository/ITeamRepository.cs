using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface ITeamRepository : IRepository<Team>
    {
        IQueryable<Team> GetTeamsByMemberUserId(Guid userId);
        IQueryable<TeamMember> GetMemberships(Func<TeamMember, bool> where);
        Task<TeamMember> GetMembership(Guid teamId, Guid userId);
        Task UpdateMembership(TeamMember member);
        Task RemoveMember(Guid teamId, Guid userId);
    }
}
