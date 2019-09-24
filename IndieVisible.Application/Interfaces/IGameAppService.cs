using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Interfaces
{
    public interface IGameAppService : ICrudAppService<GameViewModel>
    {
        IEnumerable<GameListItemViewModel> GetLatest(Guid currentUserId, int count, Guid userId, GameGenre genre);

        IEnumerable<SelectListItemVo> GetByUser(Guid userId);
    }
}
