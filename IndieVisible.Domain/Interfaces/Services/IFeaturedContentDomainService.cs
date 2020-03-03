using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IFeaturedContentDomainService : IDomainService<FeaturedContent>
    {
        IQueryable<FeaturedContent> GetFeaturedNow();
    }
}