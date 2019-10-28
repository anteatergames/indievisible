using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Services
{
    public class UserFollowAppService : BaseAppService, IUserFollowAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWorkSql unitOfWork;
        private readonly IUserFollowDomainService gameFollowDomainService;

        public UserFollowAppService(IMapper mapper, IUnitOfWorkSql unitOfWork
            , IUserFollowDomainService gameFollowDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.gameFollowDomainService = gameFollowDomainService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = gameFollowDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<UserFollowViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<UserFollow> allModels = gameFollowDomainService.GetAll();

                IEnumerable<UserFollowViewModel> vms = mapper.Map<IEnumerable<UserFollow>, IEnumerable<UserFollowViewModel>>(allModels);

                return new OperationResultListVo<UserFollowViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserFollowViewModel>(ex.Message);
            }
        }

        public OperationResultVo<UserFollowViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserFollow model = gameFollowDomainService.GetById(id);

                UserFollowViewModel vm = mapper.Map<UserFollowViewModel>(model);

                return new OperationResultVo<UserFollowViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserFollowViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                gameFollowDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, UserFollowViewModel viewModel)
        {
            try
            {
                UserFollow model;

                UserFollow existing = gameFollowDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<UserFollow>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    gameFollowDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    gameFollowDomainService.Update(model);
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

        public OperationResultListVo<UserFollowViewModel> GetByUserId(Guid userId)
        {
            try
            {
                IEnumerable<UserFollow> allModels = gameFollowDomainService.GetByUserId(userId);

                IEnumerable<UserFollowViewModel> vms = mapper.Map<IEnumerable<UserFollow>, IEnumerable<UserFollowViewModel>>(allModels);

                return new OperationResultListVo<UserFollowViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserFollowViewModel>(ex.Message);
            }
        }

        public OperationResultListVo<UserFollowViewModel> GetByFollowedId(Guid followUserId)
        {
            try
            {
                IEnumerable<UserFollow> allModels = gameFollowDomainService.Search(x => x.FollowUserId == followUserId);

                IEnumerable<UserFollowViewModel> vms = mapper.Map<IEnumerable<UserFollow>, IEnumerable<UserFollowViewModel>>(allModels);

                return new OperationResultListVo<UserFollowViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserFollowViewModel>(ex.Message);
            }
        }
    }
}
