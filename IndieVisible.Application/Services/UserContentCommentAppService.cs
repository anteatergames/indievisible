using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class UserContentCommentAppService : IUserContentCommentAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContentCommentRepository _repository;

        public Guid CurrentUserId { get; set; }

        public UserContentCommentAppService(IMapper mapper, IUnitOfWork unitOfWork, IUserContentCommentRepository repository)
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

        public OperationResultListVo<UserContentCommentViewModel> GetAll()
        {
            OperationResultListVo<UserContentCommentViewModel> result;

            try
            {
                IQueryable<UserContentComment> allModels = _repository.GetAll();

                IEnumerable<UserContentCommentViewModel> vms = _mapper.Map<IEnumerable<UserContentComment>, IEnumerable<UserContentCommentViewModel>>(allModels);

                result = new OperationResultListVo<UserContentCommentViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserContentCommentViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<UserContentCommentViewModel> GetById(Guid id)
        {
            OperationResultVo<UserContentCommentViewModel> result;

            try
            {
                UserContentComment model = _repository.GetById(id);

                UserContentCommentViewModel vm = _mapper.Map<UserContentCommentViewModel>(model);

                result = new OperationResultVo<UserContentCommentViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<UserContentCommentViewModel>(ex.Message);
            }

            return result;
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

        public OperationResultVo<Guid> Save(UserContentCommentViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                UserContentComment model;

                UserContentComment existing = _repository.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = _mapper.Map(viewModel, existing);
                }
                else
                {
                    model = _mapper.Map<UserContentComment>(viewModel);
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

        public OperationResultVo Comment(UserContentCommentViewModel viewModel)
        {
            OperationResultVo response;

            bool commentAlreadyExists = _repository.GetAll().Any(x => x.UserContentId == viewModel.UserContentId && x.UserId == viewModel.UserId && x.Text.Equals(viewModel.Text));

            if (commentAlreadyExists)
            {
                response = new OperationResultVo(false);
                response.Message = "Duplicated Comment";
            }
            else
            {
                UserContentComment model = _mapper.Map<UserContentComment>(viewModel);

                _repository.Add(model);

                _unitOfWork.Commit();

                int newCount = _repository.GetAll().Count(x => x.UserContentId == model.UserContentId && x.UserId == model.UserId);

                response = new OperationResultVo<int>(newCount);
            }


            return response;
        }
    }
}
