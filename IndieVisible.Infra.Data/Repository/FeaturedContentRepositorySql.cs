using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class FeaturedContentRepositorySql : RepositorySql<FeaturedContent>, IFeaturedContentRepositorySql
    {
        public FeaturedContentRepositorySql(IndieVisibleContext context) : base(context)
        {

        }
    }
}
