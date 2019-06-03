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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INotificationAppService _notificationAppService;

        public Guid UserId { get; set; }

        public NotificationViewComponent(IHttpContextAccessor httpContextAccessor, INotificationAppService notificationAppService)
        {
            _httpContextAccessor = httpContextAccessor;
            _notificationAppService = notificationAppService;

            string id = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                UserId = new Guid(id);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(int qtd)
        {
            if (qtd == 0)
            {
                qtd = 10;
            }

            _notificationAppService.CurrentUserId = this.UserId;
            var result = _notificationAppService.GetByUserId(this.UserId, qtd);

            var model = result.Value.ToList();

            foreach (var item in model)
            {
                item.Url += String.Format("?notificationclicked={0}", item.Id);
            }

            model.DefineVisuals();

            ViewData["UnreadCount"] = model.Count(x => !x.IsRead);
            
            return View(model);
        }
    }
}
