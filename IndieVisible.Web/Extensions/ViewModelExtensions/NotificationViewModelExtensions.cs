using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Domain.Core.Enums;
using System.Collections.Generic;

namespace IndieVisible.Web.Extensions.ViewModelExtensions
{
    public static class NotificationViewModelExtensions
    {

        public static void DefineVisuals(this List<NotificationItemViewModel> vm)
        {

            foreach (NotificationItemViewModel item in vm)
            {
                item.Icon = "far fa-dot-circle";
                item.IconColor = "text-black";

                switch (item.Type)
                {
                    case NotificationType.ContentLike:
                    case NotificationType.GameLike:
                        item.Icon = "fas fa-heart";
                        item.IconColor = "text-red";
                        break;
                    case NotificationType.ContentComment:
                        item.Icon = "fas fa-comment";
                        item.IconColor = "text-black";
                        break;
                    case NotificationType.ConnectionRequest:
                        item.Icon = "fas fa-user-plus";
                        item.IconColor = "text-maroon";
                        break;
                    case NotificationType.FollowYou:
                        item.Icon = "fas fa-eye";
                        item.IconColor = "text-blue";
                        break;
                    case NotificationType.FollowYourGame:
                        item.Icon = "fas fa-eye";
                        item.IconColor = "text-purple";
                        break;
                    case NotificationType.TeamInvitation:
                        item.Icon = "fas fa-users";
                        item.IconColor = "text-green";
                        break;
                    case NotificationType.ContentPosted:
                        item.Icon = "fas fa-file";
                        item.IconColor = "text-light-blue";
                        break;
                    default:
                        item.IconColor = "text-gray";
                        break;
                }
            }
        }
    }
}
