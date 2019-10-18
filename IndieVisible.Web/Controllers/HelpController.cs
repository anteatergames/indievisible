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

        public IActionResult Advertising()
        {
            return View();
        }

        public IActionResult Articles()
        {
            return View();
        }

        public IActionResult Contributing()
        {
            return View();
        }

        public IActionResult Partners()
        {
            return View();
        }

        public IActionResult Press()
        {
            return View();
        }
    }
}