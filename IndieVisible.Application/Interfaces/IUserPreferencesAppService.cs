using IndieVisible.Application.ViewModels.UserPreferences;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserPreferencesAppService : ICrudAppService<UserPreferencesViewModel>
    {

        UserPreferencesViewModel GetByUserId(Guid userId);
    }
}
