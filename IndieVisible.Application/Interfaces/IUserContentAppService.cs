using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserContentAppService : ICrudAppService<UserContentViewModel>
    {
        IEnumerable<UserContentListItemViewModel> GetActivityFeed(ActivityFeedRequestViewModel vm);

        int CountArticles();

        OperationResultListVo<UserContentSearchViewModel> Search(Guid currentUserId, string q);
    }
}
