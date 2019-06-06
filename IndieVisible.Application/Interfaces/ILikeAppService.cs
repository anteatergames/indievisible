using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.UserLike;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

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
