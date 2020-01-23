using IndieVisible.Domain.Core.Interfaces;
using System;
using System.Text;

namespace IndieVisible.Domain.Core.Extensions
{
    public class AndSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Left { get; set; }
        public ISpecification<T> Right { get; set; }

        public string ErrorMessage
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!Left.IsSatisfied)
                {
                    sb.Append(Left.ErrorMessage);
                }

                if (!Right.IsSatisfied)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("|");
                    }

                    sb.Append(Right.ErrorMessage);
                }

                return sb.ToString();
            }
        }

        public bool IsSatisfied { get; private set; }

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        public bool IsSatisfiedBy(T item)
        {
            IsSatisfied = Left.IsSatisfiedBy(item) && Right.IsSatisfiedBy(item);

            return IsSatisfied;
        }
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

        public bool IsSatisfied { get; private set; }

        public bool IsSatisfiedBy(T item)
        {
            IsSatisfied = Left.IsSatisfiedBy(item) || Right.IsSatisfiedBy(item);

            return IsSatisfied;
        }
    }

    public class NotSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Specification { get; set; }

        public NotSpecification(ISpecification<T> specification)
        {
            Specification = specification;
        }

        public string ErrorMessage => Specification.ErrorMessage;
        public bool IsSatisfied { get; private set; }

        public bool IsSatisfiedBy(T item)
        {
            IsSatisfied = !Specification.IsSatisfiedBy(item);

            return IsSatisfied;
        }
    }
}