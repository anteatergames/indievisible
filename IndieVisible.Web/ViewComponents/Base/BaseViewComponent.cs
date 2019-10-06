using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents.Base
{
    public abstract class BaseViewComponent : ViewComponent
    {
        public Guid CurrentUserId { get; set; }

        public BaseViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            string id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                CurrentUserId = new Guid(id);
            }
        }
    }
}
