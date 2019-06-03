using Microsoft.AspNetCore.Builder;


namespace IndieVisible.Web.Middlewares.CanonicalUrl
{
    public static class CanonicalUrlMiddlewareExtensions{
        public static IApplicationBuilder UseCanonicalUrlMiddleware(this IApplicationBuilder builder, CanonicalURLMiddlewareOptions options)
        {
            return builder.UseMiddleware<CanonicalURLMiddleware>(options);
        }
    }
}