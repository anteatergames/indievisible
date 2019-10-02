using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Extensions.ViewModelExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly INotificationAppService _notificationAppService;

        public Guid CurrentUserId { get; set; }

        public NotificationViewComponent(IHttpContextAccessor httpContextAccessor, INotificationAppService notificationAppService)
        {
            _notificationAppService = notificationAppService;

            string id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                CurrentUserId = new Guid(id);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(int qtd)
        {
            if (qtd == 0)
            {
                qtd = 10;
            }

            _notificationAppService.CurrentUserId = this.CurrentUserId;
            OperationResultListVo<NotificationItemViewModel> result = _notificationAppService.GetByUserId(this.CurrentUserId, qtd);

            System.Collections.Generic.List<NotificationItemViewModel> model = result.Value.ToList();

            foreach (NotificationItemViewModel item in model)
            {
                item.Url = string.Format("{0}?notificationclicked={1}", item.Url, item.Id);
            }

            model.DefineVisuals();

            ViewData["UnreadCount"] = model.Count(x => !x.IsRead);

            return await Task.Run(() => View(model));
        }
    }
}
