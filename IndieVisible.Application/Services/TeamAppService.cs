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

        public TeamAppService(IMapper mapper, IUnitOfWork unitOfWork
            , ITeamDomainService teamDomainService
            , IProfileDomainService profileDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.teamDomainService = teamDomainService;
            this.profileDomainService = profileDomainService;
        }

        #region ICrudAPpService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = this.teamDomainService.Count();

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
                IEnumerable<Team> allModels = this.teamDomainService.GetAll();

                IEnumerable<TeamViewModel> vms = mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(allModels);

                SetUiData(currentUserId, true, vms);

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
                Team model = this.teamDomainService.GetById(id);

                if (model == null)
                {
                    return new OperationResultVo<TeamViewModel>("Team not found!");
                }

                TeamViewModel vm = mapper.Map<TeamViewModel>(model);

                var currentUserIsLeader = vm.Members.Any(x => x.Leader && x.UserId == currentUserId);

                foreach (var member in vm.Members)
                {
                    member.Permissions.CanDelete = currentUserIsLeader && !member.Leader && member.UserId != currentUserId;
                    member.ProfileImage = UrlFormatter.ProfileImage(member.UserId);
                }

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

                Team existing = this.teamDomainService.GetById(viewModel.Id);
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
                    this.teamDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    this.teamDomainService.Update(model);
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

                this.teamDomainService.Remove(id);

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
                var myProfile = profileDomainService.GetByUserId(currentUserId).FirstOrDefault();

                var newVm = new TeamViewModel();

                newVm.Members = new List<TeamMemberViewModel>();

                var meAsMember = new TeamMemberViewModel
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
                this.teamDomainService.ChangeInvitationStatus(teamId, currentUserId, InvitationStatus.Accepted, quote);

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
                this.teamDomainService.Remove(teamId, currentUserId);

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
                IEnumerable<Team> allModels = this.teamDomainService.GetTeamsByMemberUserId(userId);

                IEnumerable<TeamViewModel> vms = mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(allModels);

                SetUiData(userId, false, vms);

                return new OperationResultListVo<TeamViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<TeamViewModel>(ex.Message);
            }
        }

        public OperationResultVo RemoveMember(Guid currentUserId, Guid teamId, Guid userId)
        {
            try
            {
                // validate before

                this.teamDomainService.Remove(teamId, userId);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        } 
        #endregion

        private void SetUiData(Guid userId, bool canInteract, IEnumerable<TeamViewModel> vms)
        {
            foreach (var team in vms)
            {
                team.Permissions.CanEdit = canInteract && team.Members.Any(x => x.UserId == userId && x.Leader);
                team.Permissions.CanDelete = canInteract && team.Members.Any(x => x.UserId == userId && x.Leader);
                team.Members = team.Members.OrderByDescending(x => x.Leader).ToList();
                var index = 0;
                foreach (var member in team.Members)
                {
                    member.Index = index++;
                    member.ProfileImage = UrlFormatter.ProfileImage(member.UserId);
                }
            }
        }
    }
}
