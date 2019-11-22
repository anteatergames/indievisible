using IndieVisible.Domain.Core.Interfaces;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Specifications.Follow
{
    public class IdNotEmptySpecification : ISpecification<UserFollow>
    {
        public IdNotEmptySpecification()
        {
        }

        public string ErrorMessage => "Invalid Ids!";

        public bool IsSatisfiedBy(UserFollow item)
        {
            return item.UserId != Guid.Empty;
        }
    }
}
