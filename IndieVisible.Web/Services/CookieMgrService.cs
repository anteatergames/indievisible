using Microsoft.AspNetCore.Http;
using System;

namespace IndieVisible.Web.Services
{
    public class CookieMgrService : ICookieMgrService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieMgrService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get(string key)
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies[key];

            return cookieValueFromContext;
        }

        public void Set(string key, string value, int? expireTime, bool isEssential)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddDays(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddDays(7);

            option.IsEssential = isEssential;
            option.Secure = true;

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }
    }
}
