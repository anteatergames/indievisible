using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Controllers
{
    [Route("/search")]
    public class SearchController : SecureBaseController
    {
        public IActionResult Index(string q)
        {
            ViewData["term"] = q;
            return View();
        }
    }
}