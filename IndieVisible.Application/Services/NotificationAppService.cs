using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Application.ViewModels.UserPreferences;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationRepository _notificationRepository;

        public Guid CurrentUserId { get; set; }

        public NotificationAppService(IMapper mapper, IUnitOfWork unitOfWork, INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _notificationRepository = notificationRepository;
        }

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result = new OperationResultVo<int>(string.Empty);

            return result;
        }

        public OperationResultListVo<NotificationItemViewModel> GetAll()
        {
            OperationResultListVo<NotificationItemViewModel> result = new OperationResultListVo<NotificationItemViewModel>(string.Empty);


            return result;
        }

        public OperationResultListVo<NotificationItemViewModel> GetById(Guid id)
        {
            OperationResultListVo<NotificationItemViewModel> result = new OperationResultListVo<NotificationItemViewModel>(string.Empty);

            return result;
        }

        public OperationResultListVo<NotificationItemViewModel> GetByUserId(Guid userId, int count)
        {
            OperationResultListVo<NotificationItemViewModel> result;

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

            result = new OperationResultListVo<NotificationItemViewModel>(tempList);

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result = new OperationResultVo(string.Empty);

            return result;
        }

        public OperationResultVo<Guid> Save(UserPreferencesViewModel viewModel)
        {
            OperationResultVo<Guid> result = new OperationResultVo<Guid>(string.Empty);

            return result;
        }

        OperationResultVo<NotificationItemViewModel> ICrudAppService<NotificationItemViewModel>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public OperationResultVo<Guid> Save(NotificationItemViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                Notification model;

                // TODO validate before

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

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Notify(Guid targetUserId, NotificationType notificationType, Guid likedId, string text, string url)
        {
            NotificationItemViewModel vm = new NotificationItemViewModel();
            vm.UserId = targetUserId;
            vm.Text = text;
            vm.Url = url;
            vm.Type = notificationType;

            OperationResultVo<Guid> saveResult = this.Save(vm);

            return saveResult;
        }

        public OperationResultVo MarkAsRead(Guid id)
        {
            OperationResultVo result = new OperationResultVo(true);

            try
            {
                Notification notification = _notificationRepository.GetById(id);

                if (notification != null)
                {
                    notification.IsRead = true;
                    _notificationRepository.Update(notification);

                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }
    }
}
