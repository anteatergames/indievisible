using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Web.Areas.Tools.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Areas.Tools.Controllers
{
    public class TranslationController : ToolsBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}