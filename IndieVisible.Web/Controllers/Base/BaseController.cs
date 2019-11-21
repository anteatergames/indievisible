using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Enums;
using Microsoft.AspNetCore.Hosting;
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

            ViewBag.BaseUrl = GetBaseUrl();
        }

        protected string GetBaseUrl()
        {
            string hostUrl = WebUtility.UrlDecode($"{Request.Scheme}://{Request.Host}{Request.PathBase}");

            ViewData["protocol"] = Request.IsHttps ? "https" : "http";
            ViewData["host"] = Request.Host;

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

        protected void SetGamificationMessage(int? pointsEarned)
        {
            if (pointsEarned.HasValue && pointsEarned.Value > 0)
            {
                TempData["Message"] = SharedLocalizer["You earned {0} points. Awesome!", pointsEarned].Value;
            }
        }
    }
}