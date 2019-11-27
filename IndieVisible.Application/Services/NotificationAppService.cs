using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Application.Services
{
    public class NotificationAppService : BaseAppService, INotificationAppService
    {
        private readonly INotificationRepository notificationRepository;

        public NotificationAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , INotificationRepository notificationRepository) : base(mapper, unitOfWork, cacheService)
        {
            this.notificationRepository = notificationRepository;
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

                Task<Notification> task = notificationRepository.GetById(viewModel.Id);
                task.Wait();

                Notification existing = task.Result;

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
                    notificationRepository.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    notificationRepository.Update(model);
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
            List<Notification> notifications = notificationRepository.Get(x => x.UserId == userId).OrderByDescending(x => x.CreateDate).Take(count).ToList();

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
                Task<Notification> task = notificationRepository.GetById(id);

                task.Wait();

                Notification notification = task.Result;

                if (notification != null)
                {
                    notification.IsRead = true;
                    notificationRepository.Update(notification);

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