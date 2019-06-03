using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IndieVisible.Web.Middlewares.CanonicalUrl
{
    public class CanonicalURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CanonicalURLMiddlewareOptions _options;

        public CanonicalURLMiddleware(RequestDelegate next, CanonicalURLMiddlewareOptions options){
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context){
            var canonicalUrl = context.Request.Path.ToString();
            if(_options.TrailingSlash)
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

            var queryString = context.Request.QueryString.ToString();
            if(_options.LowerCaseUrls)
            {
                //If you want lowercase urls but the querystrings are case sensitive
                if (_options.QueryStringCaseSensitive && !string.IsNullOrEmpty(queryString))
                {
                    canonicalUrl = canonicalUrl.ToLower() + queryString;
                }
                else
                {
                    canonicalUrl = (canonicalUrl + queryString).ToLower(); ;
                }
            }

            var oldPath = context.Request.Path.ToString() + context.Request.QueryString.ToString();
            if(!string.Equals(canonicalUrl, oldPath))
            {
                context.Response.Redirect(canonicalUrl);
            }

            await _next.Invoke(context);
        }
    }
}