using IndieVisible.Domain.Core.Interfaces;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Specifications.Follow
{
    public class UserNotTheSameSpecification : ISpecification<UserFollow>
    {
        private Guid currentUserId;

        public UserNotTheSameSpecification(Guid currentUserId)
        {
            this.currentUserId = currentUserId;
        }

        public string ErrorMessage => "Can't follow the same user!";

        public bool IsSatisfiedBy(UserFollow item) => item.Id != this.currentUserId;
    }
}
