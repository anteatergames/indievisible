using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class TeamDomainService : BaseDomainMongoService<Team, ITeamRepository>, ITeamDomainService
    {
        public TeamDomainService(ITeamRepository repository) : base(repository)
        {
        }

        public override IEnumerable<Team> GetAll()
        {
            IQueryable<Team> qry = repository.Get();

            return qry.OrderByDescending(x => x.CreateDate).ToList();
        }

        public IQueryable<TeamMember> GetAllMembershipsByUser(Guid userId)
        {
            IQueryable<TeamMember> qry = repository.GetMemberships(x => x.UserId == userId);

            return qry;
        }

        public TeamMember GetMemberByUserId(Guid teamId, Guid userId)
        {
            TeamMember obj = repository.GetMembership(teamId, userId);

            return obj;
        }

        public void ChangeInvitationStatus(Guid teamId, Guid userId, InvitationStatus invitationStatus, string quote)
        {
            TeamMember member = repository.GetMembership(teamId, userId);

            if (member != null)
            {
                member.InvitationStatus = invitationStatus;
                member.Quote = quote;
            }

            repository.UpdateMembership(teamId, member);
        }

        public void Remove(Guid teamId, Guid userId)
        {
            TeamMember member = repository.GetMembership(teamId, userId);

            if (member != null)
            {
                repository.RemoveMember(teamId, userId);
            }
        }

        public IQueryable<Team> GetTeamsByMemberUserId(Guid userId)
        {
            IQueryable<Team> teams = repository.GetTeamsByMemberUserId(userId);

            return teams;
        }
    }
}
