namespace Domain.SharedKernel;

public interface IReadOnlyRepository<TEntity, in TKey> : IDisposable 
    where TEntity : IEntity<TKey> 
    where TKey : IEquatable<TKey>
{
    Task<TEntity> GetByIdAsync(TKey id);
}