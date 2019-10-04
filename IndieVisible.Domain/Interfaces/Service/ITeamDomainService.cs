using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface ITeamDomainService : IDomainService<Team>
    {
        IEnumerable<TeamMember> GetMembers(Guid teamId);

        TeamMember GetMemberByUserId(Guid userId);

        IQueryable<TeamMember> GetAllMembershipsByUser(Guid userId);

        void ChangeInvitationStatus(Guid teamId, Guid userId, InvitationStatus invitationStatus, string quote);

        void Remove(Guid teamId, Guid userId);

        IQueryable<Team> GetTeamsByMemberUserId(Guid userId);
    }
}
