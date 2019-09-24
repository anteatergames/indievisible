using System;

namespace IndieVisible.Application.ViewModels.User
{
    public class UserConnectionViewModel : BaseViewModel
    {
        public Guid TargetUserId { get; set; }

        public string TargetUserName { get; set; }

        public string ProfileImageUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public Guid ProfileId { get; set; }
        public string Location { get; internal set; }
    }
}
