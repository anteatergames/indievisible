namespace IndieVisible.Domain.Core.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T item);

        string ErrorMessage { get; }
    }
}