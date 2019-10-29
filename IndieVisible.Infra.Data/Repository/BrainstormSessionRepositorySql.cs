using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class BrainstormSessionRepositorySql : Repository<BrainstormSession>, IBrainstormSessionRepositorySql
    {
        public BrainstormSessionRepositorySql(IndieVisibleContext context) : base(context)
        {
        }
    }
}
