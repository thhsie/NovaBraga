using Domain.Pricing;
using Infrastructure.Context;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class PricingReadOnlyRepository(NovaBragaDbContext context)
    : BaseReadOnlyRepository<Pricing, Guid>(context), IPricingReadOnlyRepository
{
    public async Task<IEnumerable<Pricing>> GetByProductIdAsync(
        Guid productId, CancellationToken cancellationToken = default)
    {
        return await Context.Pricing
            .AsNoTracking()
            .Where(p => p.ProductId == productId)
            .OrderBy(p => productId)
            .ToListAsync(cancellationToken);
    }
}
