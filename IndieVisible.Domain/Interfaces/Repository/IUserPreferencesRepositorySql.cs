using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IUserPreferencesRepositorySql : IRepositorySql<UserPreferences>
    {
        new UserPreferences GetByUserId(Guid id);
    }
}
