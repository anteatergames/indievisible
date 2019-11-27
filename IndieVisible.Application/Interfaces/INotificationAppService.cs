using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface INotificationAppService : ICrudAppService<NotificationItemViewModel>
    {
        OperationResultListVo<NotificationItemViewModel> GetByUserId(Guid userId, int count);

        OperationResultVo Notify(Guid currentUserId, Guid targetUserId, NotificationType notificationType, Guid targetId, string text, string url);

        OperationResultVo MarkAsRead(Guid id);
    }
}