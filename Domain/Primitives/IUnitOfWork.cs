using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Primitives;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
}