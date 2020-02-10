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
        private readonly RequestDelegate _next;
        private readonly string _rootUrl;

        private readonly List<string> forbiddenAreas;

        private readonly List<KeyValuePair<string, string>> forbidden;

        public SitemapMiddleware(RequestDelegate next, string rootUrl)
        {
            _next = next;
            _rootUrl = rootUrl;
            forbiddenAreas = new List<string>
            {
                "member",
                "staff"
            };

            forbidden = new List<KeyValuePair<string, string>>
            {
                { "routes", "*" },
                { "storage", "*" },
                { "user", "*" },
                { "*", "new" },
                { "*", "help" },

                { "*", "edit" },
                { "*", "delete" },
                { "*", "details" },

                { "account", "lockout" },
                { "account", "externallogin" },
                { "account", "resetpassword" },
                { "account", "forgotpasswordconfirmation" },
                { "account", "resetpasswordconfirmation" },
                { "account", "accessdenied" },

                { "home", "error" },
                { "home", "counters" },
                { "home", "notifications" },
                { "home", "errortest" },

                { "user", "listprofiles" },

                { "manage", "resetauthenticatorwarning" },
                { "manage", "showrecoverycodes" },
                { "manage", "error" },
                { "manage", "showrecoverycodes" },

                { "game", "latest" },
                { "game", "list" },
                { "game", "byteam" },

                { "content", "feed" },

                { "brainstorm", "list" },
                { "brainstorm", "newsession" },
                { "brainstorm", "newidea" },
                { "brainstorm", "details" },

                { "userbadge", "list" },

                { "help", "index" },
                { "search", "searchposts" },

                { "team", "listbyuser" },
                { "team", "acceptinvitation" },
                { "team", "rejectinvitation" },
                { "team", "deleteteam" },
                { "team", "removemember" },
                { "team", "listmyteams" },

                { "userbadge", "listbyuser" },

                { "jobposition", "list" }
            };
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
            bool isDelete = method.CustomAttributes.Any(x => x.AttributeType == typeof(HttpDeleteAttribute));
            bool isPut = method.CustomAttributes.Any(x => x.AttributeType == typeof(HttpPutAttribute));
            bool areaForbidden = forbiddenAreas.Any(x => controller.Namespace.ToLower().Contains(".areas." + x));

            if (!isPost && !isDelete && !isPut && !areaForbidden && !isForbidden)
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