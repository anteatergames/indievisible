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
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserBadgeDomainService userBadgeDomainService;

        public Guid CurrentUserId { get; set; }

        public UserBadgeAppService(IMapper mapper, IUnitOfWork unitOfWork, IUserBadgeDomainService userBadgeDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.userBadgeDomainService = userBadgeDomainService;
        }

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = userBadgeDomainService.Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<UserBadgeViewModel> GetAll(Guid currentUserId)
        {
            OperationResultListVo<UserBadgeViewModel> result;

            try
            {
                IEnumerable<UserBadge> allModels = userBadgeDomainService.GetAll();

                IEnumerable<UserBadgeViewModel> vms = mapper.Map<IEnumerable<UserBadge>, IEnumerable<UserBadgeViewModel>>(allModels);

                result = new OperationResultListVo<UserBadgeViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserBadgeViewModel>(ex.Message);
            }

            return result;
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

        public OperationResultListVo<UserBadgeViewModel> GetByUser(Guid userId)
        {
            OperationResultListVo<UserBadgeViewModel> result;

            try
            {
                IEnumerable<UserBadge> allModels = userBadgeDomainService.GetByUserId(userId);

                IEnumerable<UserBadgeViewModel> vms = mapper.Map<IEnumerable<UserBadge>, IEnumerable<UserBadgeViewModel>>(allModels);

                result = new OperationResultListVo<UserBadgeViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserBadgeViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(UserBadgeViewModel viewModel)
        {
            OperationResultVo<Guid> result;

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

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                userBadgeDomainService.Remove(id);

                unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }
    }
}