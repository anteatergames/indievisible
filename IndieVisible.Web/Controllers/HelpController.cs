using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Controllers
{
    public class HelpController : SecureBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Articles()
        {
            return View();
        }
    }
}