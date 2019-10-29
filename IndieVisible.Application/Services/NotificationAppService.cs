using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class NotificationAppService : BaseAppService, INotificationAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkSql _unitOfWork;
        private readonly INotificationRepositorySql _notificationRepository;

        public NotificationAppService(IMapper mapper, IUnitOfWorkSql unitOfWork, INotificationRepositorySql notificationRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _notificationRepository = notificationRepository;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            return new OperationResultVo<int>(string.Empty);
        }

        public OperationResultListVo<NotificationItemViewModel> GetAll(Guid currentUserId)
        {
            return new OperationResultListVo<NotificationItemViewModel>(string.Empty);
        }

        public OperationResultListVo<NotificationItemViewModel> GetById(Guid id)
        {
            return new OperationResultListVo<NotificationItemViewModel>(string.Empty);
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, NotificationItemViewModel viewModel)
        {
            try
            {
                Notification model;

                Notification existing = _notificationRepository.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = _mapper.Map(viewModel, existing);
                }
                else
                {
                    model = _mapper.Map<Notification>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    _notificationRepository.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    _notificationRepository.Update(model);
                }

                _unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            return new OperationResultVo(string.Empty);
        }
        #endregion

        public OperationResultListVo<NotificationItemViewModel> GetByUserId(Guid userId, int count)
        {
            List<Notification> notifications = _notificationRepository.Get(x => x.UserId == userId).OrderByDescending(x => x.CreateDate).Take(count).ToList();

            List<NotificationItemViewModel> tempList = new List<NotificationItemViewModel>();
            foreach (Notification notification in notifications)
            {
                NotificationItemViewModel vm = new NotificationItemViewModel
                {
                    Id = notification.Id,
                    UserId = notification.UserId,
                    Text = notification.Text,
                    Url = notification.Url,
                    IsRead = notification.IsRead,
                    CreateDate = notification.CreateDate,
                    Type = notification.Type
                };

                tempList.Add(vm);
            }

            return new OperationResultListVo<NotificationItemViewModel>(tempList);

        }

        OperationResultVo<NotificationItemViewModel> ICrudAppService<NotificationItemViewModel>.GetById(Guid currentUserId, Guid id)
        {
            throw new NotImplementedException();
        }

        public OperationResultVo Notify(Guid currentUserId, Guid targetUserId, NotificationType notificationType, Guid targetId, string text, string url)
        {
            NotificationItemViewModel vm = new NotificationItemViewModel
            {
                UserId = targetUserId,
                Text = text,
                Url = url,
                Type = notificationType
            };

            return Save(currentUserId, vm);
        }

        public OperationResultVo MarkAsRead(Guid id)
        {
            try
            {
                Notification notification = _notificationRepository.GetById(id);

                if (notification != null)
                {
                    notification.IsRead = true;
                    _notificationRepository.Update(notification);

                    _unitOfWork.Commit();
                }

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}
