using IndieVisible.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public bool CurrentUserLiked { get; set; }

        public bool CurrentUserFollowing { get; set; }

        public PermissionsVo Permissions { get; set; }

        public BaseViewModel()
        {
            Permissions = new PermissionsVo();
        }
    }
}
