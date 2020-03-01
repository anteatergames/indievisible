using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.Interfaces
{
    public interface IPermissionControl<TViewModel>
    {
        void SetPermissions(Guid currentUserId, TViewModel vm);
    }
}
