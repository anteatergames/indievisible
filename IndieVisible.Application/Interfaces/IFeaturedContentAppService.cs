using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Home;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Interfaces
{
    public interface IFeaturedContentAppService : ICrudAppService<FeaturedContentViewModel>
    {
        CarouselViewModel GetFeaturedNow();

        OperationResultVo<Guid> Add(Guid userId, Guid contentId, string title, string introduction);

        IEnumerable<UserContentToBeFeaturedViewModel> GetContentToBeFeatured();

        OperationResultVo Unfeature(Guid id);
    }
}