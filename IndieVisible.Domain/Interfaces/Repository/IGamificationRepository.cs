using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IGamificationRepository : IRepository<Gamification>
    {
        Gamification GetByUserId(Guid userId);
    }
}
