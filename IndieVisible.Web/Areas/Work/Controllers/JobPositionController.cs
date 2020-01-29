using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndieVisible.Application.Interfaces;
using IndieVisible.Web.Areas.Work.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace IndieVisible.Web.Areas.Work.Controllers
{
    public class JobPositionController : WorkBaseController
    {
        private readonly IJobPositionAppService jobPositionAppService;

        public JobPositionController(IJobPositionAppService jobPositionAppService)
        {
            this.jobPositionAppService = jobPositionAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("jobposition/list")]
        public PartialViewResult List()
        {
            return PartialView("_List");
        }
    }
}