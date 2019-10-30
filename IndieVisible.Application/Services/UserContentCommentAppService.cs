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
        private readonly IUnitOfWorkSql _unitOfWork;
        private readonly IUserContentCommentRepositorySql _repository;

        public UserContentCommentAppService(IMapper mapper, IUnitOfWorkSql unitOfWork, IUserContentCommentRepositorySql repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = _repository.GetAll().Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<UserContentCommentViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IQueryable<UserContentComment> allModels = _repository.GetAll();

                IEnumerable<UserContentCommentViewModel> vms = _mapper.Map<IEnumerable<UserContentComment>, IEnumerable<UserContentCommentViewModel>>(allModels);

                return new OperationResultListVo<UserContentCommentViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserContentCommentViewModel>(ex.Message);
            }
        }

        public OperationResultVo<UserContentCommentViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserContentComment model = _repository.GetById(id);

                UserContentCommentViewModel vm = _mapper.Map<UserContentCommentViewModel>(model);

                return new OperationResultVo<UserContentCommentViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserContentCommentViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                _repository.Remove(id);

                _unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, UserContentCommentViewModel viewModel)
        {
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

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        //public OperationResultVo Comment(UserContentCommentViewModel viewModel)
        //{
        //    bool commentAlreadyExists = _repository.GetAll().Any(x => x.UserContentId == viewModel.UserContentId && x.UserId == viewModel.UserId && x.Text.Equals(viewModel.Text));

        //    if (commentAlreadyExists)
        //    {
        //        return new OperationResultVo(false)
        //        {
        //            Message = "Duplicated Comment"
        //        };
        //    }
        //    else
        //    {
        //        UserContentComment model = _mapper.Map<UserContentComment>(viewModel);

        //        _repository.Add(model);

        //        _unitOfWork.Commit();

        //        int newCount = _repository.GetAll().Count(x => x.UserContentId == model.UserContentId && x.UserId == model.UserId);

        //        return new OperationResultVo<int>(newCount);
        //    }
        //}
    }
}
