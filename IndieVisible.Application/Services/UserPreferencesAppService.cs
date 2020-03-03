using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class UserPreferencesAppService : BaseAppService, IUserPreferencesAppService
    {
        private readonly IUserPreferencesDomainService userPreferencesDomainService;

        public UserPreferencesAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IUserPreferencesDomainService userPreferencesDomainService) : base(mapper, unitOfWork, cacheService)
        {
            this.userPreferencesDomainService = userPreferencesDomainService;
        }

        #region ICrudAppService

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = userPreferencesDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<UserPreferencesViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<UserPreferences> allModels = userPreferencesDomainService.GetAll();

                IEnumerable<UserPreferencesViewModel> vms = mapper.Map<IEnumerable<UserPreferences>, IEnumerable<UserPreferencesViewModel>>(allModels);

                return new OperationResultListVo<UserPreferencesViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserPreferencesViewModel>(ex.Message);
            }
        }

        public OperationResultVo<UserPreferencesViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserPreferences model = userPreferencesDomainService.GetById(id);

                UserPreferencesViewModel vm = mapper.Map<UserPreferencesViewModel>(model);

                return new OperationResultVo<UserPreferencesViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserPreferencesViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                userPreferencesDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, UserPreferencesViewModel viewModel)
        {
            try
            {
                UserPreferences model;

                if (viewModel.Id == viewModel.UserId)
                {
                    viewModel.Id = Guid.Empty;
                }

                UserPreferences existing = userPreferencesDomainService.GetById(viewModel.Id);

                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<UserPreferences>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    userPreferencesDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    userPreferencesDomainService.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        #endregion ICrudAppService

        public UserPreferencesViewModel GetByUserId(Guid userId)
        {
            IEnumerable<UserPreferences> list = userPreferencesDomainService.GetByUserId(userId);

            UserPreferences model = list.FirstOrDefault();

            if (model == null)
            {
                model = new UserPreferences
                {
                    UserId = userId
                };
            }

            UserPreferencesViewModel vm = mapper.Map<UserPreferencesViewModel>(model);

            return vm;
        }
    }
}