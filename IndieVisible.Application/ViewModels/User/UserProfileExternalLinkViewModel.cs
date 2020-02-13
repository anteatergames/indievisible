using System;

namespace IndieVisible.Application.ViewModels.User
{
    public class UserProfileExternalLinkViewModel : ExternalLinkBaseViewModel
    {
        public Guid UserProfileId { get; set; }
        public int Order { get; set; }
    }
}