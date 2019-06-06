using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Web.Middlewares
{
    public class SitemapMiddleware
    {
        private RequestDelegate _next;
        private string _rootUrl;

        private List<string> forbiddenAreas;

        private List<KeyValuePair<string, string>> forbidden;

        public SitemapMiddleware(RequestDelegate next, string rootUrl)
        {
            _next = next;
            _rootUrl = rootUrl;
            forbiddenAreas = new List<string>();
            forbiddenAreas.Add("member");
            forbiddenAreas.Add("staff");

            forbidden = new List<KeyValuePair<string, string>>();
            forbidden.Add("routes", "*");
            forbidden.Add("storage", "*");
            forbidden.Add("user", "*");

            forbidden.Add("*", "edit");

            forbidden.Add("account", "lockout");
            forbidden.Add("account", "externallogin");
            forbidden.Add("account", "resetpassword");
            forbidden.Add("account", "forgotpasswordconfirmation");
            forbidden.Add("account", "resetpasswordconfirmation");
            forbidden.Add("account", "accessdenied");

            forbidden.Add("home", "error");
            forbidden.Add("home", "counters");
            forbidden.Add("home", "notifications");

            forbidden.Add("user", "listprofiles");

            forbidden.Add("manage", "resetauthenticatorwarning");
            forbidden.Add("manage", "showrecoverycodes");
            forbidden.Add("manage", "error");
            forbidden.Add("manage", "showrecoverycodes");

            forbidden.Add("game", "latest");
            forbidden.Add("game", "list");

            forbidden.Add("content", "feed");

            forbidden.Add("brainstorm", "list");
            forbidden.Add("brainstorm", "newsession");
            forbidden.Add("brainstorm", "newidea");

            forbidden.Add("userbadge", "list");
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Equals("/sitemap.xml", StringComparison.OrdinalIgnoreCase))
            {
                Stream stream = context.Response.Body;
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/xml";
                string sitemapContent = "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">";

                Assembly assembly = Assembly.GetExecutingAssembly();

                List<Type> controllers = assembly.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type)
                    || type.Name.EndsWith("controller")).ToList();

                foreach (Type controller in controllers)
                {
                    sitemapContent = CheckController(sitemapContent, controller);
                }

                sitemapContent += "</urlset>";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(sitemapContent);
                    memoryStream.Write(bytes, 0, bytes.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(stream, bytes.Length);
                }
            }
            else
            {
                await _next(context);
            }
        }

        private string CheckController(string sitemapContent, Type controller)
        {
            IEnumerable<MethodInfo> methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                    .Where(method => typeof(IActionResult).IsAssignableFrom(method.ReturnType));

            foreach (MethodInfo method in methods)
            {
                sitemapContent = CheckMethod(sitemapContent, controller, method);
            }

            return sitemapContent;
        }

        private string CheckMethod(string sitemapContent, Type controller, MethodInfo method)
        {
            string controllerName = controller.Name.ToLower().Replace("controller", "");
            string actionName = method.Name.ToLower();

            bool isForbidden = forbidden.Contains(new KeyValuePair<string, string>(controllerName, actionName));
            isForbidden = isForbidden || forbidden.Contains(new KeyValuePair<string, string>(controllerName, "*"));
            isForbidden = isForbidden || forbidden.Contains(new KeyValuePair<string, string>("*", actionName));

            bool isPost = method.CustomAttributes.Any(x => x.AttributeType == typeof(HttpPostAttribute));
            bool areaForbidden = forbiddenAreas.Any(x => controller.Namespace.ToLower().Contains(".areas." + x));
            bool controllerForbidden = false;
            bool methodForbidden = false;

            if (!isPost && !areaForbidden && !isForbidden && !controllerForbidden && !methodForbidden)
            {
                sitemapContent += "<url>";

                RouteAttribute routeAttribute = method.GetCustomAttributes<RouteAttribute>().FirstOrDefault();

                if (routeAttribute != null && !routeAttribute.Template.Contains("{"))
                {
                    sitemapContent += string.Format("<loc>{0}/{1}/</loc>", _rootUrl.Trim('/'), routeAttribute.Template.Trim('/'));
                }
                else
                {
                    string methodName = method.Name.ToLower().Equals("index") ? string.Empty : actionName;
                    if (string.IsNullOrWhiteSpace(methodName))
                    {
                        sitemapContent += string.Format("<loc>{0}/{1}/</loc>", _rootUrl.Trim('/'), controllerName.Trim('/'));
                    }
                    else
                    {
                        sitemapContent += string.Format("<loc>{0}/{1}/{2}/</loc>", _rootUrl.Trim('/'), controllerName.Trim('/'), methodName.Trim('/'));
                    }
                }

                sitemapContent += string.Format("<lastmod>{0}</lastmod>", DateTime.UtcNow.ToString("yyyy-MM-dd"));
                sitemapContent += "</url>";
            }

            return sitemapContent;
        }
    }

    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseSitemapMiddleware(this IApplicationBuilder app, string rootUrl = "https://www.indievisible.net")
        {
            return app.UseMiddleware<SitemapMiddleware>(new[] { rootUrl });
        }
    }

    public static class ListExtension
    {
        public static void Add(this List<KeyValuePair<string, string>> list, string key, string value)
        {
            list.Add(new KeyValuePair<string, string>(key, value));
        }
    }
}
