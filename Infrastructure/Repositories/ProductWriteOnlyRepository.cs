using Domain.Products;
using Infrastructure.Context;
using Infrastructure.Repositories.Common;

namespace Infrastructure.Repositories;

internal class ProductWriteOnlyRepository(NovaBragaDbContext context)
    : BaseWriteOnlyRepository<Product, Guid>(context), IProductWriteOnlyRepository;