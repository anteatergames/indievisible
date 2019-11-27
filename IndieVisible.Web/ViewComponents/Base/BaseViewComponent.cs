using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Security.Claims;

namespace IndieVisible.Web.ViewComponents.Base
{
    public abstract class BaseViewComponent : ViewComponent
    {
        private IStringLocalizer<SharedResources> _sharedLocalizer;
        public IStringLocalizer<SharedResources> SharedLocalizer => _sharedLocalizer ?? (_sharedLocalizer = (IStringLocalizer<SharedResources>)HttpContext?.RequestServices.GetService(typeof(IStringLocalizer<SharedResources>)));

        public Guid CurrentUserId { get; set; }

        protected BaseViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            string id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                CurrentUserId = new Guid(id);
            }
        }
    }
}