using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IPermissionControl<TViewModel>
    {
        void SetPermissions(Guid currentUserId, TViewModel vm);
    }
}
