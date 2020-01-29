using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class UserPreferencesAppService : BaseAppService, IUserPreferencesAppService
    {
        private readonly IUserPreferencesRepository userPreferencesRepository;

        public UserPreferencesAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IUserPreferencesRepository repository) : base(mapper, unitOfWork, cacheService)
        {
            userPreferencesRepository = repository;
        }

        #region ICrudAppService

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                System.Threading.Tasks.Task<int> count = userPreferencesRepository.Count();

                count.Wait();

                return new OperationResultVo<int>(count.Result);
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
                IQueryable<UserPreferences> allModels = userPreferencesRepository.Get();

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
                System.Threading.Tasks.Task<UserPreferences> model = userPreferencesRepository.GetById(id);

                model.Wait();

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
                userPreferencesRepository.Remove(id);

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

                System.Threading.Tasks.Task<UserPreferences> task = userPreferencesRepository.GetById(viewModel.Id);

                task.Wait();

                UserPreferences existing = task.Result;

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
                    userPreferencesRepository.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    userPreferencesRepository.Update(model);
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
            System.Threading.Tasks.Task<IEnumerable<UserPreferences>> task = userPreferencesRepository.GetByUserId(userId);

            task.Wait();

            UserPreferences model = task.Result.FirstOrDefault();

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