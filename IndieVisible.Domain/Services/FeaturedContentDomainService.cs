using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class FeaturedContentDomainService : BaseDomainMongoService<FeaturedContent, IFeaturedContentRepository>, IFeaturedContentDomainService
    {
        public FeaturedContentDomainService(IFeaturedContentRepository repository) : base(repository)
        {
        }

        public IQueryable<FeaturedContent> GetFeaturedNow()
        {
            var now = DateTime.Now;

            var objs = repository.Get(x => x.StartDate <= now && (!x.EndDate.HasValue || x.EndDate > now));

            return objs;
        }
    }
}
