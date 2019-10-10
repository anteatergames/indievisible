using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Web.Controllers
{
    [Route("routes")]
    public class RoutesController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public RoutesController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        [HttpGet]
        [HttpPut]
        public IActionResult Index()
        {
            IReadOnlyList<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor> items = _actionDescriptorCollectionProvider.ActionDescriptors.Items;

            List<RouteInfo> routes = items.Select(x => new RouteInfo
            {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                Name = x.AttributeRouteInfo?.Name,
                Template = x.AttributeRouteInfo?.Template,
                Constraint = x.ActionConstraints == null ? string.Empty : string.Join(", ", x.ActionConstraints?.OfType<HttpMethodActionConstraint>().SingleOrDefault()?.HttpMethods ?? new string[] { "any" })
            }).ToList();

            return View(new RoutesModel { Routes = routes });
        }
    }

    public class RoutesModel
    {
        public List<RouteInfo> Routes { get; set; }
    }

    public class RouteInfo
    {
        public string Template { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Constraint { get; set; }
    }
}
