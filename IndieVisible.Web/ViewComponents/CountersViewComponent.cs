using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Home;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Web.ViewComponents.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class CountersViewComponent : BaseViewComponent
    {
        private readonly IGameAppService gameAppService;
        private readonly IProfileAppService profileAppService;
        private readonly IUserContentAppService contentService;
        private readonly ITeamAppService teamAppService;

        public CountersViewComponent(IHttpContextAccessor httpContextAccessor
            , IGameAppService gameAppService
            , IProfileAppService profileAppService
            , IUserContentAppService contentService
            , ITeamAppService teamAppService) : base(httpContextAccessor)
        {
            this.gameAppService = gameAppService;
            this.profileAppService = profileAppService;
            this.contentService = contentService;
            this.teamAppService = teamAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CountersViewModel model = new CountersViewModel();

            OperationResultVo<int> gamesCount = gameAppService.Count(CurrentUserId);

            if (gamesCount.Success)
            {
                model.GamesCount = gamesCount.Value;
            }

            OperationResultVo<int> usersCount = profileAppService.Count(CurrentUserId);

            if (usersCount.Success)
            {
                model.UsersCount = usersCount.Value;
            }

            model.ArticlesCount = contentService.CountArticles();


            var teamCount = teamAppService.Count(this.CurrentUserId);

            if (teamCount.Success)
            {
                model.TeamCount = teamCount.Value;
            }

            return await Task.Run(() => View(model));
        }
    }
}
