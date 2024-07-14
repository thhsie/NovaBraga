namespace Domain.SharedKernel;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}