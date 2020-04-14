using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Controllers
{
    public class TestController : SecureBaseController
    {
        public IActionResult DiscordWidget()
        {
            return View();
        }
    }
}