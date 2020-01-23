using IndieVisible.Domain.Core.Interfaces;
using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Specifications
{
    public class IdNotEmptySpecification<T> : ISpecification<T>  where T : IEntity
    {
        public IdNotEmptySpecification()
        {
        }

        public string ErrorMessage => "Invalid Id!";

        public bool IsSatisfied { get; private set; }

        public bool IsSatisfiedBy(T item)
        {
            IsSatisfied = item.UserId != Guid.Empty;

            return IsSatisfied;
        }
    }
}