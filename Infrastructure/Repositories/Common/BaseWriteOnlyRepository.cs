using Domain.SharedKernel;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Common;

internal abstract class BaseWriteOnlyRepository<TEntity, Tkey>(NovaBragaDbContext context) : IWriteOnlyRepository<TEntity, Tkey>
    where TEntity : class, IEntity<Tkey>
    where Tkey : IEquatable<Tkey>
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    protected readonly NovaBragaDbContext Context = context;

    public void Insert(TEntity entity) =>
        _dbSet.Add(entity);

    public void Update(TEntity entity) =>
        _dbSet.Update(entity);

    public void Remove(TEntity entity) =>
        _dbSet.Remove(entity);

    #region IDisposable

    // To detect redundant calls.
    private bool _disposed;

    ~BaseWriteOnlyRepository() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose managed state (managed objects).
        if (disposing)
            Context.Dispose();

        _disposed = true;
    }

    #endregion
}