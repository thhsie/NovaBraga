using Domain.Products;
using Infrastructure.Context;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories;

internal class ProductReadOnlyRepository(NovaBragaDbContext context)
    : BaseReadOnlyRepository<Product, Guid>(context), IProductReadOnlyRepository;
