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
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserFollowDomainService gameFollowDomainService;

        public UserFollowAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IUserFollowDomainService gameFollowDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.gameFollowDomainService = gameFollowDomainService;
        }

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = gameFollowDomainService.Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<UserFollowViewModel> GetAll()
        {
            OperationResultListVo<UserFollowViewModel> result;

            try
            {
                IEnumerable<UserFollow> allModels = this.gameFollowDomainService.GetAll();

                IEnumerable<UserFollowViewModel> vms = mapper.Map<IEnumerable<UserFollow>, IEnumerable<UserFollowViewModel>>(allModels);

                result = new OperationResultListVo<UserFollowViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserFollowViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<UserFollowViewModel> GetByUserId(Guid userId)
        {
            OperationResultListVo<UserFollowViewModel> result;

            try
            {
                IEnumerable<UserFollow> allModels = this.gameFollowDomainService.GetByUserId(userId);

                IEnumerable<UserFollowViewModel> vms = mapper.Map<IEnumerable<UserFollow>, IEnumerable<UserFollowViewModel>>(allModels);

                result = new OperationResultListVo<UserFollowViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserFollowViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<UserFollowViewModel> GetById(Guid id)
        {
            OperationResultVo<UserFollowViewModel> result;

            try
            {
                UserFollow model = this.gameFollowDomainService.GetById(id);

                UserFollowViewModel vm = mapper.Map<UserFollowViewModel>(model);

                result = new OperationResultVo<UserFollowViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<UserFollowViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                this.gameFollowDomainService.Remove(id);

                unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(UserFollowViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                UserFollow model;

                UserFollow existing = this.gameFollowDomainService.GetById(viewModel.Id);
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
                    this.gameFollowDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    this.gameFollowDomainService.Update(model);
                }

                unitOfWork.Commit();

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<UserFollowViewModel> GetByFollowedId(Guid followUserId)
        {
            OperationResultListVo<UserFollowViewModel> result;

            try
            {
                IEnumerable<UserFollow> allModels = this.gameFollowDomainService.Search(x => x.FollowUserId == followUserId);

                IEnumerable<UserFollowViewModel> vms = mapper.Map<IEnumerable<UserFollow>, IEnumerable<UserFollowViewModel>>(allModels);

                result = new OperationResultListVo<UserFollowViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserFollowViewModel>(ex.Message);
            }

            return result;
        }
    }
}
