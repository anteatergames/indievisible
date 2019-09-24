using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System;
using System.Net;

namespace IndieVisible.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        private IStringLocalizer<SharedResources> _sharedLocalizer;
        public IStringLocalizer<SharedResources> SharedLocalizer => _sharedLocalizer ?? (_sharedLocalizer = (IStringLocalizer<SharedResources>)HttpContext?.RequestServices.GetService(typeof(IStringLocalizer<SharedResources>)));


        public BaseController()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ViewBag.BaseUrl = this.GetBaseUrl();
        }

        protected string GetBaseUrl()
        {
            var hostUrl = WebUtility.UrlDecode($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");

            ViewData["protocol"] = this.Request.IsHttps ? "https" : "http";
            ViewData["host"] = this.Request.Host;

            return hostUrl;
        }


        protected string GetSessionValue(SessionValues key)
        {
            string value = HttpContext.Session.GetString(key.ToString());

            return value;
        }
        protected void SetSessionValue(SessionValues key, string value)
        {
            HttpContext.Session.SetString(key.ToString(), value);
        }

        private void TranslateResponse(OperationResultVo response)
        {
            if (response != null && !String.IsNullOrWhiteSpace(response.Message))
            {
                response.Message = SharedLocalizer[response.Message];
            }
        }

        protected JsonResult Json(OperationResultVo data)
        {
            TranslateResponse(data);

            return base.Json(data);
        }
    }
}