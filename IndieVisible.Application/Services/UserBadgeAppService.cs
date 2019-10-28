using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Services
{
    public class UserBadgeAppService : IUserBadgeAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWorkSql unitOfWork;
        private readonly IUserBadgeDomainService userBadgeDomainService;

        public UserBadgeAppService(IMapper mapper, IUnitOfWorkSql unitOfWork, IUserBadgeDomainService userBadgeDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.userBadgeDomainService = userBadgeDomainService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = userBadgeDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<UserBadgeViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<UserBadge> allModels = userBadgeDomainService.GetAll();

                IEnumerable<UserBadgeViewModel> vms = mapper.Map<IEnumerable<UserBadge>, IEnumerable<UserBadgeViewModel>>(allModels);

                return new OperationResultListVo<UserBadgeViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserBadgeViewModel>(ex.Message);
            }
        }

        public OperationResultVo<UserBadgeViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserBadge model = userBadgeDomainService.GetById(id);

                UserBadgeViewModel vm = mapper.Map<UserBadgeViewModel>(model);

                return new OperationResultVo<UserBadgeViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserBadgeViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                userBadgeDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, UserBadgeViewModel viewModel)
        {
            try
            {
                UserBadge model;

                UserBadge existing = userBadgeDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<UserBadge>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    userBadgeDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    userBadgeDomainService.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }
        #endregion

        public OperationResultListVo<UserBadgeViewModel> GetByUserId(Guid userId)
        {
            try
            {
                IEnumerable<UserBadge> allModels = userBadgeDomainService.GetByUserId(userId);

                IEnumerable<UserBadgeViewModel> vms = mapper.Map<IEnumerable<UserBadge>, IEnumerable<UserBadgeViewModel>>(allModels);

                return new OperationResultListVo<UserBadgeViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserBadgeViewModel>(ex.Message);
            }
        }
    }
}