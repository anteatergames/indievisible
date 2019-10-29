using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IGamificationRepositorySql : IRepositorySql<Gamification>
    {
        new Gamification GetByUserId(Guid userId);
    }
}
