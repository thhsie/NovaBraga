using Domain.Pricing;
using Infrastructure.Context;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories;

internal class PricingWriteOnlyRepository(NovaBragaDbContext context)
    : BaseWriteOnlyRepository<Pricing, Guid>(context), IPricingWriteOnlyRepository;