using IndieVisible.Domain.Models;
using System.Linq;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IFeaturedContentDomainService : IDomainService<FeaturedContent>
    {
        IQueryable<FeaturedContent> GetFeaturedNow();
    }
}