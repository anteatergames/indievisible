using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface ITeamDomainService : IDomainService<Team>
    {
        TeamMember GetMemberByUserId(Guid teamId, Guid userId);

        IQueryable<TeamMember> GetAllMembershipsByUser(Guid userId);

        void ChangeInvitationStatus(Guid teamId, Guid userId, InvitationStatus invitationStatus, string quote);

        void RemoveMember(Guid teamId, Guid userId);

        IEnumerable<Team> GetTeamsByMemberUserId(Guid userId);

        IEnumerable<SelectListItemVo<Guid>> GetTeamListByMemberUserId(Guid userId);

        Team GenerateNewTeam(Guid currentUserId);
    }
}