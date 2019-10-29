using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class GameFollowRepositorySql : Repository<GameFollow>, IGameFollowRepositorySql
    {
        public GameFollowRepositorySql(IndieVisibleContext context) : base(context)
        {
        }
    }
}
