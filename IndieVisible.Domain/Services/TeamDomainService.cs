using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class TeamDomainService : BaseDomainMongoService<Team, ITeamRepository>, ITeamDomainService
    {
        private readonly IGameRepository gameRepository;

        public TeamDomainService(ITeamRepository repository, IGameRepository gameRepository) : base(repository)
        {
            this.gameRepository = gameRepository;
        }

        public override IEnumerable<Team> GetAll()
        {
            IQueryable<Team> qry = repository.Get();

            return qry.OrderByDescending(x => x.CreateDate).ToList();
        }

        public override void Remove(Guid id)
        {
            List<Game> games = gameRepository.Get(x => x.TeamId == id).ToList();

            foreach (Game game in games)
            {
                game.TeamId = null;
                gameRepository.Update(game);
            }

            base.Remove(id);
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

        public void RemoveMember(Guid teamId, Guid userId)
        {
            TeamMember member = repository.GetMembership(teamId, userId);

            if (member != null)
            {
                repository.RemoveMember(teamId, userId);
            }
        }

        public IEnumerable<Team> GetTeamsByMemberUserId(Guid userId)
        {
            List<Team> teams = repository.GetTeamsByMemberUserId(userId).ToList();

            return teams;
        }

        public IEnumerable<SelectListItemVo<Guid>> GetTeamListByMemberUserId(Guid userId)
        {
            var teams = repository.GetTeamsByMemberUserId(userId).Select(x => new { x.Name, x.Id }).ToList();

            IEnumerable<SelectListItemVo<Guid>> vos = teams.Select(x => new SelectListItemVo<Guid>
            {
                Text = x.Name,
                Value = x.Id
            });

            return vos;
        }

        public Team GenerateNewTeam(Guid currentUserId)
        {
            Team team = new Team
            {
                Members = new List<TeamMember>()
            };

            TeamMember meAsMember = new TeamMember
            {
                UserId = currentUserId,
                Leader = true,
                InvitationStatus = InvitationStatus.Accepted
            };

            team.Members.Add(meAsMember);

            return team;
        }
    }
}