using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.UserLike
{
    public class UserLikeViewModel : BaseViewModel
    {
        public Guid LikedId { get; set; }

        public LikeTargetType TargetType { get; set; }
    }
}
