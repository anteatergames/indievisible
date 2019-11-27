using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Areas.Staff.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IndieVisible.Web.Areas.Staff.Controllers
{
    [Route("staff/featuredcontent")]
    public class FeaturedContentController : StaffBaseController
    {
        private readonly IFeaturedContentAppService featuredContentAppService;

        public FeaturedContentController(IFeaturedContentAppService service)
        {
            featuredContentAppService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("list")]
        public IActionResult List()
        {
            IEnumerable<UserContentToBeFeaturedViewModel> model = featuredContentAppService.GetContentToBeFeatured();

            return PartialView("_List", model);
        }

        [HttpPost("add")]
        public IActionResult Add(Guid id, string title, string introduction)
        {
            OperationResultVo<Guid> operationResult = featuredContentAppService.Add(CurrentUserId, id, title, introduction);

            return Json(operationResult);
        }

        [HttpPost("remove")]
        public IActionResult Remove(Guid id, string title, string introduction)
        {
            OperationResultVo operationResult;

            try
            {
                operationResult = featuredContentAppService.Unfeature(id);
            }
            catch (Exception ex)
            {
                operationResult = new OperationResultVo(ex.Message);
            }

            return Json(operationResult);
        }
    }
}