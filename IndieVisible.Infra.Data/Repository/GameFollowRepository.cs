using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class GameFollowRepository : Repository<GameFollow>, IGameFollowRepository
    {
        public GameFollowRepository(IndieVisibleContext context) : base(context)
        {
        }
    }
}
