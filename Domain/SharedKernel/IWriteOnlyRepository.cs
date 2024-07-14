namespace Domain.SharedKernel;

public interface IWriteOnlyRepository<TEntity, in TKey> : IDisposable
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    void Insert(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}