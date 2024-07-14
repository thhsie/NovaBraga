namespace Domain.SharedKernel;

public interface IEntity;

public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
{
    TKey Id { get; }
}