namespace IndieVisible.Domain.Core.Interfaces
{
    public interface ISpecification
    {
        string ErrorMessage { get; }

        bool IsSatisfied { get; }
    }

    public interface ISpecification<in T> : ISpecification
    {
        bool IsSatisfiedBy(T item);
    }
}