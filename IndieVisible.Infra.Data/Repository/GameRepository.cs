using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.Context;

namespace IndieVisible.Infra.Data.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(IndieVisibleContext context) : base(context)
        {

        }
    }
}
