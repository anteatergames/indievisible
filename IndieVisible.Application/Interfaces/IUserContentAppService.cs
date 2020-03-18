using IndieVisible.Application.ViewModels;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserContentAppService : ICrudAppService<UserContentViewModel>, IProfileBaseAppService
    {
        IEnumerable<UserContentViewModel> GetActivityFeed(ActivityFeedRequestViewModel vm);

        int CountArticles();

        OperationResultListVo<UserContentSearchViewModel> Search(Guid currentUserId, string q);

        OperationResultVo ContentLike(Guid currentUserId, Guid targetId);

        OperationResultVo ContentUnlike(Guid currentUserId, Guid targetId);

        OperationResultVo Comment(CommentViewModel vm);
    }
}