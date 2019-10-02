using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class TeamDomainService : BaseDomainService<Team, ITeamRepository>, ITeamDomainService
    {
        private readonly ITeamMemberRepository teamMemberRepository;

        public TeamDomainService(ITeamRepository repository, ITeamMemberRepository teamMemberRepository) : base(repository)
        {
            this.teamMemberRepository = teamMemberRepository;
        }

        public override IEnumerable<Team> GetAll()
        {
            var qry = repository.GetAll();

            return qry.OrderByDescending(x => x.CreateDate).ToList();
        }

        public IQueryable<TeamMember> GetAllMembershipsByUser(Guid userId)
        {
            var qry = teamMemberRepository.Get(x => x.UserId == userId);

            return qry;
        }

        public TeamMember GetMemberByUserId(Guid userId)
        {
            var qry = teamMemberRepository.Get(x => x.UserId == userId);

            var obj = qry.FirstOrDefault();

            return obj;
        }

        public IEnumerable<TeamMember> GetMembers(Guid teamId)
        {
            var qry = teamMemberRepository.Get(x => x.TeamId == teamId);

            var objs = qry.ToList();

            return objs;
        }

        public void ChangeInvitationStatus(Guid teamId, Guid userId, InvitationStatus invitationStatus, string quote)
        {
            var member = this.teamMemberRepository.Get(x => x.TeamId == teamId && x.UserId == userId).FirstOrDefault();

            if (member != null)
            {
                member.InvitationStatus = invitationStatus;
                member.Quote = quote;
            }
        }

        public void Remove(Guid teamId, Guid userId)
        {
            var member = this.teamMemberRepository.Get(x => x.TeamId == teamId && x.UserId == userId).FirstOrDefault();

            if (member != null)
            {
                this.teamMemberRepository.Remove(member.Id);
            }
        }

        public IQueryable<Team> GetTeamsByMemberUserId(Guid userId)
        {
            var teams = repository.Get(x => x.Members.Any(y => y.UserId == userId));

            return teams;
        }
    }
}
