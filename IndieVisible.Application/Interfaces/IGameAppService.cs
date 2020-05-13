using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Interfaces
{
    public interface IGameAppService : ICrudAppService<GameViewModel>
    {
        OperationResultVo<GameViewModel> GetById(Guid currentUserId, Guid id, bool forEdit);

        OperationResultVo<GameViewModel> CreateNew(Guid currentUserId);

        IEnumerable<GameListItemViewModel> GetLatest(Guid currentUserId, int count, Guid userId, Guid? teamId, GameGenre genre);

        IEnumerable<SelectListItemVo> GetByUser(Guid userId);

        OperationResultVo GameFollow(Guid currentUserId, Guid gameId);

        OperationResultVo GameUnfollow(Guid currentUserId, Guid gameId);

        OperationResultVo GameLike(Guid currentUserId, Guid gameId);

        OperationResultVo GameUnlike(Guid currentUserId, Guid gameId);

        OperationResultVo GetAllIds(Guid empty);
    }
}