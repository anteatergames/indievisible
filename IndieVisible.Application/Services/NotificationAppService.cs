using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class NotificationAppService : BaseAppService, INotificationAppService
    {
        private readonly INotificationDomainService notificationDomainService;

        public NotificationAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , INotificationDomainService notificationDomainService) : base(mapper, unitOfWork, cacheService)
        {
            this.notificationDomainService = notificationDomainService;
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
        public OperationResultVo GetAllIds(Guid currentUserId)
        {
            try
            {
                IEnumerable<Guid> allIds = notificationDomainService.GetAllIds();

                return new OperationResultListVo<Guid>(allIds);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
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

                Notification existing = notificationDomainService.GetById(viewModel.Id);

                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<Notification>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    notificationDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    notificationDomainService.Update(model);
                }

                unitOfWork.Commit();

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

        #endregion ICrudAppService

        public OperationResultListVo<NotificationItemViewModel> GetByUserId(Guid userId, int count)
        {
            List<Notification> notifications = notificationDomainService.GetByUserId(userId).OrderByDescending(x => x.CreateDate).Take(count).ToList();

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
                Notification notification = notificationDomainService.GetById(id);

                if (notification != null)
                {
                    notification.IsRead = true;
                    notificationDomainService.Update(notification);

                    unitOfWork.Commit();
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