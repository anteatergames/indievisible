using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserContentAppService : ICrudAppService<UserContentViewModel>
    {
        IEnumerable<UserContentListItemViewModel> GetActivityFeed(Guid currentUserId, int count, Guid? gameId, Guid? userId, List<SupportedLanguage> languages);

        int CountArticles();

        OperationResultListVo<UserContentSearchViewModel> Search(Guid currentUserId, string q);
    }
}
