using Domain.SharedKernel;

namespace Domain.Pricing;

public interface IPricingWriteOnlyRepository : IWriteOnlyRepository<Pricing, Guid>;