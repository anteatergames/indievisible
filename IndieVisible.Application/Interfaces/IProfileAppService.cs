using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IProfileAppService : ICrudAppService<ProfileViewModel>
    {
        ProfileViewModel GetByUserId(Guid userId, ProfileType type);
        ProfileViewModel GetByUserId(Guid currentUserId, Guid userId, ProfileType type);

        ProfileViewModel GenerateNewOne(ProfileType type);
    }
}
