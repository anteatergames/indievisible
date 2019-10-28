﻿using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IUserPreferencesRepository : IRepositorySql<UserPreferences>
    {
        new UserPreferences GetByUserId(Guid id);
    }
}
