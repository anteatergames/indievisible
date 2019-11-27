using IndieVisible.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface ITeamRepository : IRepository<Team>
    {
        IQueryable<Team> GetTeamsByMemberUserId(Guid userId);

        IQueryable<TeamMember> GetMemberships(Func<TeamMember, bool> where);

        TeamMember GetMembership(Guid teamId, Guid userId);

        void UpdateMembership(Guid teamId, TeamMember member);

        Task<bool> RemoveMember(Guid teamId, Guid userId);
    }
}