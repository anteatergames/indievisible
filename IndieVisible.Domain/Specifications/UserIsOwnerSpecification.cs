using IndieVisible.Domain.Core.Interfaces;
using System;

namespace IndieVisible.Domain.Specifications
{
    public class UserIsOwnerSpecification<T> : ISpecification<T> where T : IEntity
    {
        private Guid userId;

        public UserIsOwnerSpecification(Guid userId)
        {
            this.userId = userId;
        }

        public string ErrorMessage => "This is not yours!";

        public bool IsSatisfied { get; private set; }

        public bool IsSatisfiedBy(T item)
        {
            IsSatisfied = item.UserId == userId;

            return IsSatisfied;
        }
    }
}