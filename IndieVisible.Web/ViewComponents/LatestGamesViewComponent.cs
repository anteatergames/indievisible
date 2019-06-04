using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web.ViewComponents
{
    public class LatestGamesViewComponent : ViewComponent
    {
        public Guid UserId { get; set; }

        private readonly IGameAppService _gameAppService;

        public LatestGamesViewComponent(IGameAppService gameAppService, IHttpContextAccessor httpContextAccessor)
        {
            _gameAppService = gameAppService;

            string id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(id))
            {
                UserId = new Guid(id);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(int qtd, Guid userId)
        {
            if (qtd == 0)
            {
                qtd = 3;
            }

            List<GameListItemViewModel> model = _gameAppService.GetLatest(UserId, qtd, userId, 0).ToList();

            return await Task.Run(() => View(model));
        }
    }
}
