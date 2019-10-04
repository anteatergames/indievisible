using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class UserPreferencesAppService : BaseAppService, IUserPreferencesAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserPreferencesRepository _repository;

        public UserPreferencesAppService(IMapper mapper, IUnitOfWork unitOfWork, IUserPreferencesRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = _repository.GetAll().Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<UserPreferencesViewModel> GetAll(Guid currentUserId)
        {
            OperationResultListVo<UserPreferencesViewModel> result;

            try
            {
                IQueryable<UserPreferences> allModels = _repository.GetAll();

                IEnumerable<UserPreferencesViewModel> vms = _mapper.Map<IEnumerable<UserPreferences>, IEnumerable<UserPreferencesViewModel>>(allModels);

                result = new OperationResultListVo<UserPreferencesViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserPreferencesViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<UserPreferencesViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserPreferences model = _repository.GetById(id);

                UserPreferencesViewModel vm = _mapper.Map<UserPreferencesViewModel>(model);

                return new OperationResultVo<UserPreferencesViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserPreferencesViewModel>(ex.Message);
            }
        }

        public UserPreferencesViewModel GetByUserId(Guid userId)
        {
            UserPreferences model = _repository.GetAll().FirstOrDefault(x => x.UserId == userId);

            if (model == null)
            {
                model = new UserPreferences();
                model.UserId = userId;
            }

            UserPreferencesViewModel vm = _mapper.Map<UserPreferencesViewModel>(model);

            return vm;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                _repository.Remove(id);

                _unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(UserPreferencesViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                UserPreferences model;

                if (viewModel.Id == viewModel.UserId)
                {
                    viewModel.Id = Guid.Empty;
                }

                UserPreferences existing = _repository.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = _mapper.Map(viewModel, existing);
                }
                else
                {
                    model = _mapper.Map<UserPreferences>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    _repository.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    _repository.Update(model);
                }

                _unitOfWork.Commit();

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }
    }
}
