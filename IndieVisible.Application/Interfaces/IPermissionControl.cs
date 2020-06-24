using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IPermissionControl<in TViewModel>
    {
        void SetPermissions(Guid currentUserId, TViewModel vm);
    }
}