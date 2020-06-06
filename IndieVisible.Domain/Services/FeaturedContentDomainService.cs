using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;
using System;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class FeaturedContentDomainService : BaseDomainMongoService<FeaturedContent, IFeaturedContentRepository>, IFeaturedContentDomainService
    {
        public FeaturedContentDomainService(IFeaturedContentRepository repository) : base(repository)
        {
        }

        public IQueryable<FeaturedContent> GetFeaturedNow()
        {
            DateTime now = DateTime.Now;

            IQueryable<FeaturedContent> objs = repository.Get(x => x.StartDate <= now && (!x.EndDate.HasValue || x.EndDate > now));

            return objs;
        }
    }
}