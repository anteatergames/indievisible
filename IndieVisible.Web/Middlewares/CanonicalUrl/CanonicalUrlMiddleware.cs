using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace IndieVisible.Web.Middlewares.CanonicalUrl
{
    public class CanonicalUrlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CanonicalUrlMiddlewareOptions _options;

        public CanonicalUrlMiddleware(RequestDelegate next, CanonicalUrlMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            string canonicalUrl = context.Request.Path.ToString();
            if (_options.TrailingSlash)
            {
                if (canonicalUrl.Length > 1 && !string.Equals(canonicalUrl[canonicalUrl.Length - 1], '/'))
                {
                    canonicalUrl = canonicalUrl + "/";
                }
            }
            else
            {
                if (canonicalUrl.Length > 1 && string.Equals(canonicalUrl[canonicalUrl.Length - 1], '/'))
                {
                    canonicalUrl = canonicalUrl.Substring(0, canonicalUrl.Length - 1);
                }
            }

            string queryString = context.Request.QueryString.ToString();
            if (_options.LowerCaseUrls)
            {
                //If you want lowercase urls but the querystrings are case sensitive
                if (_options.QueryStringCaseSensitive && !string.IsNullOrEmpty(queryString))
                {
                    canonicalUrl = canonicalUrl.ToLower() + queryString;
                }
                else
                {
                    canonicalUrl = (canonicalUrl + queryString).ToLower();
                }
            }

            string oldPath = context.Request.Path.ToString() + context.Request.QueryString.ToString();
            if (!string.Equals(canonicalUrl, oldPath))
            {
                context.Response.Redirect(canonicalUrl);
            }

            await _next.Invoke(context);
        }
    }
}