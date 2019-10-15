using AutoMapper;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class TeamAppService : BaseAppService, ITeamAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITeamDomainService teamDomainService;
        private readonly IProfileDomainService profileDomainService;
        private readonly IGamificationDomainService gamificationDomainService;

        public TeamAppService(IMapper mapper, IUnitOfWork unitOfWork
            , ITeamDomainService teamDomainService
            , IProfileDomainService profileDomainService
            , IGamificationDomainService gamificationDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.teamDomainService = teamDomainService;
            this.profileDomainService = profileDomainService;
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

                foreach (var team in vms)
                {
                    bool currentUserIsLeader = team.Members.Any(x => x.Leader && x.UserId == currentUserId);
                    SetUiData(currentUserId, currentUserIsLeader, team);
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

                bool currentUserIsLeader = vm.Members.Any(x => x.Leader && x.UserId == currentUserId);

                SetUiData(currentUserId, false, vm);

                vm.Members = vm.Members.OrderByDescending(x => x.Leader).ToList();

                return new OperationResultVo<TeamViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<TeamViewModel>(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, TeamViewModel viewModel)
        {
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

                    gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.TeamAdd);
                }
                else
                {
                    teamDomainService.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
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
                UserProfile myProfile = profileDomainService.GetByUserId(currentUserId).FirstOrDefault();

                TeamViewModel newVm = new TeamViewModel
                {
                    Members = new List<TeamMemberViewModel>()
                };

                TeamMemberViewModel meAsMember = new TeamMemberViewModel
                {
                    UserId = currentUserId,
                    Leader = true,
                    ProfileImage = UrlFormatter.ProfileImage(currentUserId),
                    Name = myProfile != null ? myProfile.Name : "Me",
                    InvitationStatus = InvitationStatus.Accepted
                };

                newVm.Members.Add(meAsMember);


                return new OperationResultVo<TeamViewModel>(newVm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo AcceptInvite(Guid teamId, Guid currentUserId, string quote)
        {
            try
            {
                teamDomainService.ChangeInvitationStatus(teamId, currentUserId, InvitationStatus.Accepted, quote);

                gamificationDomainService.ProcessAction(currentUserId, PlatformAction.TeamJoin);

                unitOfWork.Commit();

                return new OperationResultVo(true);
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
                IEnumerable<Team> allModels = teamDomainService.GetTeamsByMemberUserId(userId);

                IEnumerable<TeamViewModel> vms = mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(allModels);

                foreach (var team in vms)
                {
                    SetUiData(userId, false, team);
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
                IQueryable<SelectListItemVo> allModels = teamDomainService.GetTeamsByMemberUserId(userId).Select(x => new SelectListItemVo
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                return new OperationResultListVo<SelectListItemVo>(allModels);
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
        #endregion

        private void SetUiData(Guid userId, bool canInteract, TeamViewModel team)
        {
                team.Permissions.CanEdit = canInteract && team.Members.Any(x => x.UserId == userId && x.Leader);
                team.Permissions.CanDelete = canInteract && team.Members.Any(x => x.UserId == userId && x.Leader);
                team.Members = team.Members.OrderByDescending(x => x.Leader).ToList();
                foreach (TeamMemberViewModel member in team.Members)
                {
                    member.ProfileImage = UrlFormatter.ProfileImage(member.UserId);
                }
        }
    }
}
