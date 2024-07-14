using Domain.SharedKernel;

namespace Domain.Pricing;

public interface IPricingReadOnlyRepository : IReadOnlyRepository<Pricing, Guid>
{
    Task<IEnumerable<Pricing>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);
}