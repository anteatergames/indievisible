using IndieVisible.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Core.Extensions
{
    public class AndSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Left { get; set; }
        public ISpecification<T> Right { get; set; }

        public string ErrorMessage => String.Format("{0}|{1}", Left.ErrorMessage, Right.ErrorMessage);

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }
        public bool IsSatisfiedBy(T item) => Left.IsSatisfiedBy(item) && Right.IsSatisfiedBy(item);
    }

    public class OrSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Left { get; set; }
        public ISpecification<T> Right { get; set; }
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }
        public string ErrorMessage => String.Format("{0}|{1}", Left.ErrorMessage, Right.ErrorMessage);

        public bool IsSatisfiedBy(T item) => Left.IsSatisfiedBy(item) || Right.IsSatisfiedBy(item);
    }

    public class NotSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Specification { get; set; }
        public NotSpecification(ISpecification<T> specification)
        {
            Specification = specification;
        }
        public string ErrorMessage => Specification.ErrorMessage;

        public bool IsSatisfiedBy(T item) => !Specification.IsSatisfiedBy(item);
    }
}
