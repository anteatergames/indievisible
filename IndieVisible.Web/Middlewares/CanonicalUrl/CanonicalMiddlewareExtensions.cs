using Microsoft.AspNetCore.Builder;

namespace IndieVisible.Web.Middlewares.CanonicalUrl
{
    public static class CanonicalUrlMiddlewareExtensions
    {
        public static IApplicationBuilder UseCanonicalUrlMiddleware(this IApplicationBuilder builder, CanonicalUrlMiddlewareOptions options)
        {
            return builder.UseMiddleware<CanonicalUrlMiddleware>(options);
        }
    }
}