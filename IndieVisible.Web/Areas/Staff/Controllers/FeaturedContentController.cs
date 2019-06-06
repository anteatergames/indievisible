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
        private readonly IUserContentAppService _contentService;
        private readonly IFeaturedContentAppService _service;

        public FeaturedContentController(IUserContentAppService contentService, IFeaturedContentAppService service)
        {
            _contentService = contentService;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("list")]
        public IActionResult List()
        {
            IEnumerable<UserContentToBeFeaturedViewModel> model = _service.GetContentToBeFeatured();

            return PartialView("_List", model);
        }


        [HttpPost("add")]
        public IActionResult Add(Guid id, string title, string introduction)
        {
            var operationResult = _service.Add(CurrentUserId, id, title, introduction);

            return Json(operationResult);
        }


        [HttpPost("remove")]
        public IActionResult Remove(Guid id, string title, string introduction)
        {
            OperationResultVo operationResult;

            try
            {
                operationResult = _service.Unfeature(id);
            }
            catch (Exception ex)
            {
                operationResult = new OperationResultVo(ex.Message);
            }

            return Json(operationResult);
        }
    }
}