using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class GameLikeRepository : Repository<GameLike>, IGameLikeRepository
    {
        public GameLikeRepository(IndieVisibleContext context) : base(context)
        {

        }
    }
}
