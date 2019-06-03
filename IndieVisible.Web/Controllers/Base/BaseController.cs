using IndieVisible.Application.Interfaces;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Application.ViewModels;
using System;

namespace IndieVisible.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        private IStringLocalizer<SharedResources> _sharedLocalizer;
        public IStringLocalizer<SharedResources> SharedLocalizer => _sharedLocalizer ?? (_sharedLocalizer = (IStringLocalizer<SharedResources>)HttpContext?.RequestServices.GetService(typeof(IStringLocalizer<SharedResources>)));
        

        public BaseController()
        {
        }

        protected string GetBaseUrl()
        {
            return WebUtility.UrlDecode($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
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
    }
}