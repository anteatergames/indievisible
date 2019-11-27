using IndieVisible.Application.ViewModels.UserPreferences;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserPreferencesAppService : ICrudAppService<UserPreferencesViewModel>
    {
        UserPreferencesViewModel GetByUserId(Guid userId);
    }
}