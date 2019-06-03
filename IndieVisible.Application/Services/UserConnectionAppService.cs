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
    public class UserConnectionAppService : BaseAppService, IUserConnectionAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserConnectionDomainService userConnectionDomainService;

        public UserConnectionAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IUserConnectionDomainService userConnectionDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.userConnectionDomainService = userConnectionDomainService;
        }

        #region Basic
        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = this.userConnectionDomainService.Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<UserConnectionViewModel> GetAll()
        {
            OperationResultListVo<UserConnectionViewModel> result;

            try
            {
                IEnumerable<UserConnection> allModels = this.userConnectionDomainService.GetAll();

                IEnumerable<UserConnectionViewModel> vms = mapper.Map<IEnumerable<UserConnection>, IEnumerable<UserConnectionViewModel>>(allModels);

                result = new OperationResultListVo<UserConnectionViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserConnectionViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<UserConnectionViewModel> GetById(Guid id)
        {
            OperationResultVo<UserConnectionViewModel> result;

            try
            {
                UserConnection model = this.userConnectionDomainService.GetById(id);

                UserConnectionViewModel vm = mapper.Map<UserConnectionViewModel>(model);

                result = new OperationResultVo<UserConnectionViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<UserConnectionViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                this.userConnectionDomainService.Remove(id);

                unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(UserConnectionViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                UserConnection model;

                // TODO validate before

                UserConnection existing = this.userConnectionDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<UserConnection>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    this.userConnectionDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    this.userConnectionDomainService.Update(model);
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
        #endregion

        public OperationResultListVo<UserConnectionViewModel> GetByTargetUserId(Guid targetUserId)
        {
            OperationResultListVo<UserConnectionViewModel> result;

            try
            {
                IEnumerable<UserConnection> allModels = this.userConnectionDomainService.GetByTargetUserId(targetUserId);

                IEnumerable<UserConnectionViewModel> vms = mapper.Map<IEnumerable<UserConnection>, IEnumerable<UserConnectionViewModel>>(allModels);

                result = new OperationResultListVo<UserConnectionViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserConnectionViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Connect(Guid currentUserId, Guid userId)
        {
            try
            {
                Guid newId;

                UserConnection model = new UserConnection
                {
                    UserId = currentUserId,
                    TargetUserId = userId
                };

                // TODO validate before

                UserConnection existing = this.userConnectionDomainService.Get(currentUserId, userId);

                if (existing != null)
                {
                    return new OperationResultVo("You are already connected to this user!");
                }
                else
                {

                    this.userConnectionDomainService.Add(model);

                    newId = model.Id;
                }

                unitOfWork.Commit();

                int newCount = this.userConnectionDomainService.Count(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Disconnect(Guid currentUserId, Guid userId)
        {
            try
            {
                // validate before

                UserConnection toMe = this.userConnectionDomainService.Get(currentUserId, userId);
                UserConnection fromMe = this.userConnectionDomainService.Get(userId, currentUserId);

                if (toMe == null && fromMe == null)
                {
                    return new OperationResultVo("You are not connected to this user!");
                }
                else
                {
                    if (toMe != null)
                    {
                        this.userConnectionDomainService.Remove(toMe.Id);
                    }
                    if (fromMe != null)
                    {
                        this.userConnectionDomainService.Remove(fromMe.Id);
                    }
                }

                unitOfWork.Commit();

                int newCount = this.userConnectionDomainService.Count(x => x.TargetUserId == userId);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Allow(Guid currentUserId, Guid userId)
        {
            OperationResultVo result;

            try
            {
                // TODO validate before

                UserConnection existing = this.userConnectionDomainService.Get(userId, currentUserId);

                if (existing == null)
                {
                    result = new OperationResultVo("There is no connection requested by this user.");
                }
                else
                {
                    existing.ApprovalDate = DateTime.Now;

                    this.userConnectionDomainService.Update(existing);
                }

                unitOfWork.Commit();

                int newCount = this.userConnectionDomainService.Count(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                result = new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo Deny(Guid currentUserId, Guid userId)
        {
            OperationResultVo result;

            try
            {
                // TODO validate before

                UserConnection existing = this.userConnectionDomainService.Get(userId, currentUserId);

                if (existing == null)
                {
                    result = new OperationResultVo("There is no connection requested by this user.");
                }
                else
                {
                    this.userConnectionDomainService.Remove(existing.Id);
                }

                unitOfWork.Commit();

                int newCount = this.userConnectionDomainService.Count(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                result = new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }
    }
}
