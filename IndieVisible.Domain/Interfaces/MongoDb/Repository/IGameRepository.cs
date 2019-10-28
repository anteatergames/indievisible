using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<bool> Follow(Guid userId, Guid gameId);
        Task<bool> Unfollow(Guid userId, Guid gameId);
        Task<bool> Like(Guid currentUserId, Guid gameId);
        Task<bool> Unlike(Guid currentUserId, Guid gameId);
        Task<int> CountFollowers(Guid gameId);
        Task<int> CountLikes(Guid gameId);
    }
}
