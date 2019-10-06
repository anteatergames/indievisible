using IndieVisible.Application.ViewModels.UserLike;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface ILikeAppService : ICrudAppService<UserLikeViewModel>
    {
        OperationResultVo ContentLike(Guid currentUserId, Guid likedId);

        OperationResultVo ContentUnlike(Guid currentUserId, Guid likedId);


        OperationResultVo GameLike(Guid currentUserId, Guid gameId);

        OperationResultVo GameUnlike(Guid currentUserId, Guid likedId);
    }
}
