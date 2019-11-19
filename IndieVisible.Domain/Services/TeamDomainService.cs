using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
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

        public IEnumerable<Team> GetTeamsByMemberUserId(Guid userId)
        {
            var teams = repository.GetTeamsByMemberUserId(userId).ToList();

            return teams;
        }

        public IEnumerable<SelectListItemVo<Guid>> GetTeamListByMemberUserId(Guid userId)
        {
            var teams = repository.GetTeamsByMemberUserId(userId).Select(x => new { x.Name, x.Id }).ToList();

            var vos = teams.Select(x => new SelectListItemVo<Guid>
            {
                Text = x.Name,
                Value = x.Id
            });

            return vos;
        }
    }
}
