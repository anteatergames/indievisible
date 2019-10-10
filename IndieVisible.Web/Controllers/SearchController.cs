using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

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

        [Route("posts/{q}")]
        public IActionResult SearchPosts(string q)
        {
            OperationResultListVo<UserContentSearchViewModel> result = userContentAppService.Search(CurrentUserId, q);

            return View("_SearchPostsResult", result.Value);
        }
    }
}