using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class UserConnectionAppService : BaseAppService, IUserConnectionAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserConnectionDomainService userConnectionDomainService;
        private readonly IProfileAppService profileAppService;

        public UserConnectionAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IUserConnectionDomainService userConnectionDomainService
            , IProfileAppService profileAppService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.userConnectionDomainService = userConnectionDomainService;
            this.profileAppService = profileAppService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = userConnectionDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<UserConnectionViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<UserConnection> allModels = userConnectionDomainService.GetAll();

                IEnumerable<UserConnectionViewModel> vms = mapper.Map<IEnumerable<UserConnection>, IEnumerable<UserConnectionViewModel>>(allModels);

                return new OperationResultListVo<UserConnectionViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserConnectionViewModel>(ex.Message);
            }
        }

        public OperationResultVo<UserConnectionViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserConnection model = userConnectionDomainService.GetById(id);

                UserConnectionViewModel vm = mapper.Map<UserConnectionViewModel>(model);

                return new OperationResultVo<UserConnectionViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserConnectionViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                userConnectionDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, UserConnectionViewModel viewModel)
        {
            try
            {
                UserConnection model;

                UserConnection existing = userConnectionDomainService.GetById(viewModel.Id);
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
                    userConnectionDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    userConnectionDomainService.Update(model);
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

        public OperationResultListVo<UserConnectionViewModel> GetByTargetUserId(Guid targetUserId)
        {
            try
            {
                IEnumerable<UserConnection> allModels = userConnectionDomainService.GetByTargetUserId(targetUserId, false);

                IEnumerable<UserConnectionViewModel> vms = mapper.Map<IEnumerable<UserConnection>, IEnumerable<UserConnectionViewModel>>(allModels);

                return new OperationResultListVo<UserConnectionViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserConnectionViewModel>(ex.Message);
            }
        }

        public OperationResultListVo<UserConnectionViewModel> GetByUserId(Guid userId)
        {
            try
            {
                List<UserConnectionViewModel> newList = new List<UserConnectionViewModel>();

                IEnumerable<UserConnection> connectionsFromMe = userConnectionDomainService.GetByUserId(userId, true);
                IEnumerable<UserConnection> connectionsToMe = userConnectionDomainService.GetByTargetUserId(userId, true);

                foreach (UserConnection item in connectionsFromMe)
                {
                    if (!newList.Any(x => x.UserId == item.TargetUserId))
                    {
                        ProfileViewModel profile = profileAppService.GetByUserId(item.TargetUserId, ProfileType.Personal);

                        UserConnectionViewModel obj = new UserConnectionViewModel
                        {
                            UserId = userId,
                            TargetUserId = item.TargetUserId,
                            TargetUserName = profile.Name,
                            ProfileId = profile.Id,
                            Location = profile.Location,
                            CreateDate = profile.CreateDate
                        };

                        newList.Add(obj);
                    }
                }

                foreach (UserConnection item in connectionsToMe)
                {
                    if (!newList.Any(x => x.UserId == item.UserId))
                    {
                        ProfileViewModel profile = profileAppService.GetByUserId(item.UserId, ProfileType.Personal);

                        UserConnectionViewModel obj = new UserConnectionViewModel
                        {
                            UserId = userId,
                            TargetUserId = item.UserId,
                            TargetUserName = profile.Name,
                            ProfileId = profile.Id,
                            Location = profile.Location,
                            CreateDate = profile.CreateDate
                        };

                        newList.Add(obj);
                    }
                }

                return new OperationResultListVo<UserConnectionViewModel>(newList);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserConnectionViewModel>(ex.Message);
            }
        }

        public OperationResultVo Connect(Guid currentUserId, Guid userId)
        {
            try
            {
                UserConnection model = new UserConnection
                {
                    UserId = currentUserId,
                    TargetUserId = userId
                };

                UserConnection existing = userConnectionDomainService.Get(currentUserId, userId);

                if (existing != null)
                {
                    return new OperationResultVo("You are already connected to this user!");
                }
                else
                {

                    userConnectionDomainService.Add(model);
                }

                unitOfWork.Commit();

                int newCount = userConnectionDomainService.Count(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

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

                UserConnection toMe = userConnectionDomainService.Get(currentUserId, userId);
                UserConnection fromMe = userConnectionDomainService.Get(userId, currentUserId);

                if (toMe == null && fromMe == null)
                {
                    return new OperationResultVo("You are not connected to this user!");
                }
                else
                {
                    if (toMe != null)
                    {
                        userConnectionDomainService.Remove(toMe.Id);
                    }
                    if (fromMe != null)
                    {
                        userConnectionDomainService.Remove(fromMe.Id);
                    }
                }

                unitOfWork.Commit();

                int newCount = userConnectionDomainService.Count(x => x.TargetUserId == userId);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Allow(Guid currentUserId, Guid userId)
        {
            try
            {
                UserConnection existing = userConnectionDomainService.Get(userId, currentUserId);

                if (existing == null)
                {
                    return new OperationResultVo("There is no connection requested by this user.");
                }
                else
                {
                    existing.ApprovalDate = DateTime.Now;

                    userConnectionDomainService.Update(existing);
                }

                unitOfWork.Commit();

                int newCount = userConnectionDomainService.Count(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Deny(Guid currentUserId, Guid userId)
        {
            try
            {
                UserConnection existing = userConnectionDomainService.Get(userId, currentUserId);

                if (existing == null)
                {
                    return new OperationResultVo("There is no connection requested by this user.");
                }
                else
                {
                    userConnectionDomainService.Remove(existing.Id);
                }

                unitOfWork.Commit();

                int newCount = userConnectionDomainService.Count(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}
