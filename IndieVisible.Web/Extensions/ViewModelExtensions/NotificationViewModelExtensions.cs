using IndieVisible.Application.ViewModels.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Extensions.ViewModelExtensions
{
    public static class NotificationViewModelExtensions
    {

        public static void DefineVisuals(this List<NotificationItemViewModel> vm)
        {

            foreach (var item in vm)
            {
                switch (item.Type)
                {
                    case Domain.Core.Enums.NotificationType.ContentLike:
                        item.Icon = "fas fa-heart";
                        item.IconColor = "text-red";
                        break;
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
                        item.Icon = "far fa-dot-circle";
                        item.IconColor = "text-black";
                        break;
                    case Domain.Core.Enums.NotificationType.LevelUp:
                        item.Icon = "far fa-dot-circle";
                        item.IconColor = "text-black";
                        break;
                    case Domain.Core.Enums.NotificationType.ArticleAboutYourGame:
                        item.Icon = "far fa-dot-circle";
                        item.IconColor = "text-black";
                        break;
                    case Domain.Core.Enums.NotificationType.ContentPosted:
                        item.Icon = "fas fa-asterisk";
                        item.IconColor = "text-green";
                        break;
                    default:
                        item.Icon = "far fa-dot-circle";
                        item.IconColor = "text-black";
                        break;
                }
            }
        }
    }
}
