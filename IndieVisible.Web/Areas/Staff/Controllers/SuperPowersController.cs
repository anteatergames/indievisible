using IndieVisible.Web.Areas.Staff.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Areas.Staff.Controllers
{
    public class SuperPowersController : StaffBaseController
    {
        public IActionResult Index()
        {
            CookieMgrService.Set("user_is_admin", "true", 1, true);

            ViewData["user_is_admin"] = true;

            return View();
        }
    }
}