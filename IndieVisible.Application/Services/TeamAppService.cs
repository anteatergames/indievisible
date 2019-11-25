using AutoMapper;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class TeamAppService : ProfileBaseAppService, ITeamAppService
    {
        private readonly ITeamDomainService teamDomainService;
        private readonly IGamificationDomainService gamificationDomainService;

        public TeamAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , ITeamDomainService teamDomainService
            , IProfileDomainService profileDomainService
            , IGamificationDomainService gamificationDomainService) : base(mapper, unitOfWork, cacheService, profileDomainService)
        {
            this.teamDomainService = teamDomainService;
            this.gamificationDomainService = gamificationDomainService;
        }

        #region ICrudAPpService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = teamDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<TeamViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<Team> allModels = teamDomainService.GetAll();

                IEnumerable<TeamViewModel> vms = mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(allModels);

                foreach (TeamViewModel team in vms)
                {
                    SetUiData(currentUserId, team);
                }

                return new OperationResultListVo<TeamViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<TeamViewModel>(ex.Message);
            }
        }

        public OperationResultVo<TeamViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                Team model = teamDomainService.GetById(id);

                if (model == null)
                {
                    return new OperationResultVo<TeamViewModel>("Team not found!");
                }

                TeamViewModel vm = mapper.Map<TeamViewModel>(model);

                vm.Members = vm.Members.OrderByDescending(x => x.Leader).ToList();
                foreach (TeamMemberViewModel member in vm.Members)
                {
                    var profile = GetCachedProfileByUserId(member.UserId);
                    member.Name = profile.Name;
                    member.Permissions.IsMe = member.UserId == currentUserId;
                    member.WorkDictionary = member.Works.ToDisplayName();
                }

                vm.CurrentUserIsMember = model.Members.Any(x => x.UserId == currentUserId);

                if (vm.Recruiting)
                {
                    UserProfile myProfile = GetCachedProfileByUserId(currentUserId);

                    vm.Candidate = new TeamMemberViewModel
                    {
                        UserId = currentUserId,
                        InvitationStatus = InvitationStatus.Candidate,
                        Name = myProfile.Name
                    };
                }

                SetUiData(currentUserId, vm);

                return new OperationResultVo<TeamViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<TeamViewModel>(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, TeamViewModel viewModel)
        {
            int pointsEarned = 0;

            try
            {
                Team model;

                Team existing = teamDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<Team>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    teamDomainService.Add(model);
                    viewModel.Id = model.Id;

                    pointsEarned += gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.TeamAdd);
                }
                else
                {
                    teamDomainService.Update(model);
                }

                unitOfWork.Commit();

                viewModel.Id = model.Id;

                return new OperationResultVo<Guid>(model.Id, pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                teamDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
        #endregion


        #region ITeamAppService
        public OperationResultVo GenerateNewTeam(Guid currentUserId)
        {
            try
            {
                var newTeam = teamDomainService.GenerateNewTeam(currentUserId);

                var newVm = mapper.Map<TeamViewModel>(newTeam);
                UserProfile myProfile = GetCachedProfileByUserId(currentUserId);

                var me = newVm.Members.FirstOrDefault(x => x.UserId == currentUserId);
                me.Name = myProfile.Name;
                me.ProfileImage = UrlFormatter.ProfileImage(currentUserId);

                return new OperationResultVo<TeamViewModel>(newVm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo AcceptInvite(Guid teamId, Guid currentUserId, string quote)
        {
            int pointsEarned = 0;

            try
            {
                teamDomainService.ChangeInvitationStatus(teamId, currentUserId, InvitationStatus.Accepted, quote);

                pointsEarned += gamificationDomainService.ProcessAction(currentUserId, PlatformAction.TeamJoin);

                unitOfWork.Commit();

                return new OperationResultVo(true, pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo RejectInvite(Guid teamId, Guid currentUserId)
        {
            try
            {
                teamDomainService.Remove(teamId, currentUserId);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetByUserId(Guid userId)
        {
            try
            {
                var allModels = teamDomainService.GetTeamsByMemberUserId(userId);

                IEnumerable<TeamViewModel> vms = mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(allModels);

                foreach (TeamViewModel team in vms)
                {
                    SetUiData(userId, team);
                }

                return new OperationResultListVo<TeamViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<TeamViewModel>(ex.Message);
            }
        }

        public OperationResultVo GetSelectListByUserId(Guid userId)
        {
            try
            {
                var allModels = teamDomainService.GetTeamListByMemberUserId(userId);

                var list = allModels.Select(x => new SelectListItemVo
                {
                    Text = x.Text,
                    Value = x.Value.ToString()
                });

                return new OperationResultListVo<SelectListItemVo>(list);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo RemoveMember(Guid currentUserId, Guid teamId, Guid userId)
        {
            try
            {
                // validate before

                teamDomainService.Remove(teamId, userId);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo CandidateApply(Guid currentUserId, TeamMemberViewModel vm)
        {
            int pointsEarned = 0;

            try
            {
                Team team = teamDomainService.GetById(vm.TeamId);

                if (team == null)
                {
                    return new OperationResultVo("Team not found!");
                }

                TeamMember teamMemberModel = mapper.Map<TeamMember>(vm);

                team.Members.Add(teamMemberModel);

                pointsEarned += gamificationDomainService.ProcessAction(currentUserId, PlatformAction.TeamJoin);

                unitOfWork.Commit();

                return new OperationResultVo(true, "Application sent! Now just sit and wait the team leader to accept you.", pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo AcceptCandidate(Guid currentUserId, Guid teamId, Guid userId)
        {
            try
            {
                TeamMember member = teamDomainService.GetMemberByUserId(teamId, userId);

                member.InvitationStatus = InvitationStatus.Accepted;

                unitOfWork.Commit();

                return new OperationResultVo(true, "Member accepted!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo RejectCandidate(Guid currentUserId, Guid teamId, Guid userId)
        {
            try
            {
                teamDomainService.Remove(teamId, userId);

                unitOfWork.Commit();

                return new OperationResultVo(true, "Member accepted!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
        #endregion

        private void SetUiData(Guid userId, TeamViewModel team)
        {
            bool userIsLeader = team.Members.Any(x => x.Leader && x.UserId == userId);

            team.Permissions.CanEdit = userIsLeader && team.Members.Any(x => x.UserId == userId && x.Leader);
            team.Permissions.CanDelete = userIsLeader && team.Members.Any(x => x.UserId == userId && x.Leader);
            team.Members = team.Members.OrderByDescending(x => x.Leader).ToList();

            foreach (TeamMemberViewModel member in team.Members)
            {
                member.Permissions.CanDelete = member.UserId != userId && team.Permissions.CanDelete;
                member.ProfileImage = UrlFormatter.ProfileImage(member.UserId);
            }

            if (team.Candidate != null)
            {
                team.Candidate.ProfileImage = UrlFormatter.ProfileImage(team.Candidate.UserId);
            }
        }
    }
}
