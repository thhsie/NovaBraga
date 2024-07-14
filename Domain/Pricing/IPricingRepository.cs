namespace Domain.Pricing;

public interface IPricingRepository
{
    Task<IEnumerable<Pricing>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);

    void Insert(Pricing pricing);
}