using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Web.Areas.Member.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Areas.Member.Controllers
{
    public class MessageController : MemberBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}