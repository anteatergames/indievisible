using IndieVisible.Application.ViewModels.UserLike;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface ILikeAppService : ICrudAppService<UserLikeViewModel>
    {
        OperationResultVo ContentLike(Guid likedId);

        OperationResultVo ContentUnlike(Guid likedId);


        OperationResultVo GameLike(Guid gameId);

        OperationResultVo GameUnlike(Guid likedId);
    }
}
