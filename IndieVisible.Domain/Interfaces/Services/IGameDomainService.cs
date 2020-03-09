using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Linq;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IGameDomainService : IDomainService<Game>
    {
        IQueryable<Game> Get(GameGenre genre, Guid userId, Guid? teamId);

        bool Follow(Guid userId, Guid gameId);

        bool Unfollow(Guid userId, Guid gameId);

        bool Like(Guid userId, Guid gameId);

        bool Unlike(Guid userId, Guid gameId);

        int CountFollowers(Guid gameId);

        int CountLikes(Guid gameId);
    }
}