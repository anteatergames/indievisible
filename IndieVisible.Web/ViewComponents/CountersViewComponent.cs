using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Home;
using IndieVisible.Web.ViewComponents.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class CountersViewComponent : BaseViewComponent
    {
        private readonly IGameAppService _gameAppService;
        private readonly IProfileAppService _profileAppService;
        private readonly IUserContentAppService _contentService;

        public CountersViewComponent(IHttpContextAccessor httpContextAccessor, IGameAppService gameAppService, IProfileAppService profileAppService, IUserContentAppService contentService) : base(httpContextAccessor)
        {
            _gameAppService = gameAppService;
            _profileAppService = profileAppService;
            _contentService = contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CountersViewModel model = new CountersViewModel();

            Domain.ValueObjects.OperationResultVo<int> gamesCount = _gameAppService.Count(CurrentUserId);

            if (gamesCount.Success)
            {
                model.GamesCount = gamesCount.Value;
            }

            Domain.ValueObjects.OperationResultVo<int> usersCount = _profileAppService.Count(CurrentUserId);

            if (usersCount.Success)
            {
                model.UsersCount = usersCount.Value;
            }

            model.ArticlesCount = _contentService.CountArticles();


            return await Task.Run(() => View(model));
        }
    }
}
