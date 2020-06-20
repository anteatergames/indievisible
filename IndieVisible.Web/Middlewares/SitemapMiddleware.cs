using IndieVisible.Application.Interfaces;
using IndieVisible.Domain.ValueObjects;
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

        public IGameAppService GameAppService { get; private set; }

        public IProfileAppService ProfileAppService { get; private set; }

        public IUserContentAppService ContentAppService { get; private set; }

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
                { "test", "*" },

                { "*", "new" },
                { "*", "help" },

                { "*", "edit" },
                { "*", "delete" },

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

                { "brainstorm", "details" },
                { "brainstorm", "list" },
                { "brainstorm", "newsession" },
                { "brainstorm", "newidea" },

                { "userbadge", "list" },

                { "help", "index" },
                { "search", "searchposts" },

                { "team", "details" },
                { "team", "list" },
                { "team", "listbyuser" },
                { "team", "acceptinvitation" },
                { "team", "rejectinvitation" },
                { "team", "deleteteam" },
                { "team", "removemember" },
                { "team", "listmyteams" },

                { "userbadge", "listbyuser" },

                { "jobposition", "details" },
                { "jobposition", "list" },
                { "jobposition", "listmine" },
                { "jobposition", "mypositionsstats" },
                { "jobposition", "myapplications" },

                { "localization", "details" },
                { "localization", "list" },
                { "localization", "listmine" },
                { "localization", "translate" },
                { "localization", "export" },
                { "localization", "exportxml" },
                { "localization", "exportcontributors" },
                { "localization", "review" },
                { "localization", "getterms" }
            };
        }

        public async Task Invoke(HttpContext context, IGameAppService gameAppService, IProfileAppService profileAppService, IUserContentAppService contentAppService)
        {
            StringBuilder sb = new StringBuilder();

            GameAppService = gameAppService;
            ProfileAppService = profileAppService;
            ContentAppService = contentAppService;

            if (context.Request.Path.Value.Equals("/sitemap.xml", StringComparison.OrdinalIgnoreCase))
            {
                Stream stream = context.Response.Body;
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/xml";
                sb.Append("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

                Assembly assembly = Assembly.GetExecutingAssembly();

                List<Type> controllers = assembly.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type)
                    || type.Name.EndsWith("controller")).ToList();

                foreach (Type controller in controllers)
                {
                    sb.AppendLine(CheckController(controller));
                }

                sb.AppendLine("</urlset>");
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
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

        private string CheckController(Type controller)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<MethodInfo> methods = controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                    .Where(method => typeof(IActionResult).IsAssignableFrom(method.ReturnType));

            foreach (MethodInfo method in methods)
            {
                sb.AppendLine(CheckMethod(controller, method));
            }

            List<string> detailMethods = CheckDetailsMethod(controller);

            foreach (string method in detailMethods)
            {
                sb.AppendLine(method);
            }

            return sb.ToString();
        }

        private string CheckMethod(Type controller, MethodInfo method)
        {
            bool isPost = method.CustomAttributes.Any(x => x.AttributeType == typeof(HttpPostAttribute));
            bool isDelete = method.CustomAttributes.Any(x => x.AttributeType == typeof(HttpDeleteAttribute));
            bool isPut = method.CustomAttributes.Any(x => x.AttributeType == typeof(HttpPutAttribute));

            RouteAttribute routeAttribute = method.GetCustomAttributes<RouteAttribute>().FirstOrDefault();

            bool hasParameter = routeAttribute != null && !routeAttribute.Template.Contains("{");
            string routeTemplate = routeAttribute != null ? routeAttribute.Template.Trim('/') : string.Empty;

            string actionName = method.Name.ToLower();

            return CheckMethod(controller, actionName, isPost, isDelete, isPut, hasParameter, routeTemplate);
        }

        private List<string> CheckDetailsMethod(Type controller)
        {
            string pattern = string.Empty;
            OperationResultVo ids = null;
            List<string> methodList = new List<string>();

            if (controller.Name.Equals("ProfileController"))
            {
                pattern = "profile/{0}";
                ids = ProfileAppService.GetAllIds(Guid.Empty);
            }
            else if (controller.Name.Equals("GameController"))
            {
                pattern = "game/{0}";
                ids = GameAppService.GetAllIds(Guid.Empty);
            }
            else if (controller.Name.Equals("ContentController"))
            {
                pattern = "content/{0}";
                ids = ContentAppService.GetAllIds(Guid.Empty);
            }

            if (ids != null && !string.IsNullOrWhiteSpace(pattern))
            {
                List<string> urls = GetDetailUrls(controller, ids, pattern);

                methodList.AddRange(urls);
            }

            return methodList;
        }

        private List<string> GetDetailUrls(Type controller, OperationResultVo result, string patternUrl)
        {
            List<string> methodList = new List<string>();

            if (result.Success)
            {
                OperationResultListVo<Guid> castResult = result as OperationResultListVo<Guid>;

                foreach (Guid userId in castResult.Value)
                {
                    string route = string.Format(patternUrl, userId.ToString());

                    string sitemapItem = CheckMethod(controller, "details", false, false, false, true, route);

                    methodList.Add(sitemapItem);
                }
            }

            return methodList;
        }

        private string CheckMethod(Type controller, string actionName, bool isPost, bool isDelete, bool isPut, bool hasParameter, string routeTemplate)
        {
            string sitemapContent = string.Empty;

            string controllerName = controller.Name.ToLower().Replace("controller", "");

            bool isForbidden = forbidden.Contains(new KeyValuePair<string, string>(controllerName, actionName));
            isForbidden = isForbidden || forbidden.Contains(new KeyValuePair<string, string>(controllerName, "*"));
            isForbidden = isForbidden || forbidden.Contains(new KeyValuePair<string, string>("*", actionName));
            bool areaForbidden = forbiddenAreas.Any(x => controller.Namespace.ToLower().Contains(".areas." + x));

            if (!isPost && !isDelete && !isPut && !areaForbidden && !isForbidden)
            {
                sitemapContent += "<url>";

                if (hasParameter)
                {
                    sitemapContent += string.Format("<loc>{0}/{1}/</loc>", _rootUrl.Trim('/'), routeTemplate);
                }
                else
                {
                    string methodName = actionName.Equals("index") ? string.Empty : actionName;
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