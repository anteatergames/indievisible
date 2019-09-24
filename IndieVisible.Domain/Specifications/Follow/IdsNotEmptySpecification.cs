using IndieVisible.Domain.Core.Interfaces;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Specifications.Follow
{
    public class IdsNotEmptySpecification : ISpecification<UserFollow>
    {
        public IdsNotEmptySpecification()
        {
        }

        public string ErrorMessage => "Invalid Ids!";

        public bool IsSatisfiedBy(UserFollow item)
        {
            return item.UserId != Guid.Empty && item.FollowUserId != Guid.Empty;
        }
    }
}
