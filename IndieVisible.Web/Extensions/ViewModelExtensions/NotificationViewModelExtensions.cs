using IndieVisible.Application.ViewModels.Notification;
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
                    case Domain.Core.Enums.NotificationType.ContentLike:
                    case Domain.Core.Enums.NotificationType.GameLike:
                        item.Icon = "fas fa-heart";
                        item.IconColor = "text-red";
                        break;
                    case Domain.Core.Enums.NotificationType.ContentComment:
                        item.Icon = "fas fa-comment";
                        item.IconColor = "text-black";
                        break;
                    case Domain.Core.Enums.NotificationType.ConnectionRequest:
                        item.Icon = "fas fa-user-plus";
                        item.IconColor = "text-maroon";
                        break;
                    case Domain.Core.Enums.NotificationType.FollowYou:
                        item.Icon = "fas fa-eye";
                        item.IconColor = "text-blue";
                        break;
                    case Domain.Core.Enums.NotificationType.FollowYourGame:
                        item.Icon = "fas fa-eye";
                        item.IconColor = "text-purple";
                        break;
                    case Domain.Core.Enums.NotificationType.AchivementEarned:
                    case Domain.Core.Enums.NotificationType.LevelUp:
                    case Domain.Core.Enums.NotificationType.ArticleAboutYourGame:
                    case Domain.Core.Enums.NotificationType.ContentPosted:
                    default:
                        item.IconColor = "text-gray";
                        break;
                }
            }
        }
    }
}
