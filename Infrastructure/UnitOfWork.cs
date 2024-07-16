using System.Data;
using Domain.SharedKernel;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

internal sealed class UnitOfWork(
    NovaBragaDbContext novaBragaDbContext,
    ILogger<UnitOfWork> logger) : IUnitOfWork
{
    public async Task SaveChangesAsync()
    {
        // Creating the execution strategy (Connection resiliency and database retries).
        var strategy = novaBragaDbContext.Database.CreateExecutionStrategy();

        // Executing the strategy.
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await novaBragaDbContext.Database.BeginTransactionAsync();

            logger.LogInformation("----- Begin transaction: '{TransactionId}'", transaction.TransactionId);

            try
            {
                var rowsAffected = await novaBragaDbContext.SaveChangesAsync();

                logger.LogInformation("----- Commit transaction: '{TransactionId}'", transaction.TransactionId);

                await transaction.CommitAsync();

                logger.LogInformation(
                    "----- Transaction successfully confirmed: '{TransactionId}', Rows Affected: {RowsAffected}",
                    transaction.TransactionId,
                    rowsAffected);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An unexpected exception occurred while committing the transaction: '{TransactionId}', message: {Message}",
                    transaction.TransactionId,
                    ex.Message);

                await transaction.RollbackAsync();

                throw;
            }
        });
    }
    
    #region IDisposable

    // To detect redundant calls.
    private bool _disposed;

    // Public implementation of Dispose pattern callable by consumers.
    ~UnitOfWork() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    private void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose managed state (managed objects).
        if (disposing)
        {
            novaBragaDbContext.Dispose();
        }

        _disposed = true;
    }

    #endregion
}