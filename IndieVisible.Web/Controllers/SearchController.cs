using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IndieVisible.Web.Controllers
{
    [Route("/search")]
    public class SearchController : SecureBaseController
    {
        private readonly IUserContentAppService userContentAppService;

        public SearchController(IUserContentAppService userContentAppService)
        {
            this.userContentAppService = userContentAppService;
        }

        public IActionResult Index(string q)
        {
            ViewData["term"] = q;
            return View();
        }

        [Route("posts")]
        public IActionResult SearchPosts(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return View("_SearchPostsResult", new UserContentSearchViewModel());
            }
            else
            {
                OperationResultListVo<UserContentSearchViewModel> result = userContentAppService.Search(CurrentUserId, q);
                return View("_SearchPostsResult", result.Value);
            }
        }

        [HttpGet("getcities")]
        public IActionResult SearchCities(string q, string country)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return Json(new List<SelectListItemVo>());
            }
            else
            {
                var result = userContentAppService.GetCities(CurrentUserId, country, q);

                if (result.Success)
                {
                    OperationResultListVo<SelectListItemVo> castResult = result as OperationResultListVo<SelectListItemVo>;

                    return Json(castResult.Value);
                }

                return Json(new List<SelectListItemVo>());
            }
        }
    }
}