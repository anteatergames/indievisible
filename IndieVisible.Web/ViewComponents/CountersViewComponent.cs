using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class CountersViewComponent : ViewComponent
    {
        private readonly IGameAppService _gameAppService;
        private readonly IProfileAppService _profileAppService;
        private readonly IUserContentAppService _contentService;

        public CountersViewComponent(IGameAppService gameAppService, IProfileAppService profileAppService, IUserContentAppService contentService)
        {
            _gameAppService = gameAppService;
            _profileAppService = profileAppService;
            _contentService = contentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int qtd)
        {
            var model = new CountersViewModel();

            var gamesCount = _gameAppService.Count();

            if (gamesCount.Success)
            {
                model.GamesCount = gamesCount.Value;
            }

            var usersCount = _profileAppService.Count();

            if (usersCount.Success)
            {
                model.UsersCount = usersCount.Value;
            }

            model.ArticlesCount = _contentService.CountArticles();


            return await Task.Run(() => View(model));
        }
    }
}
