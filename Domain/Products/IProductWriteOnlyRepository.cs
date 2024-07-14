using Domain.SharedKernel;

namespace Domain.Products;

public interface IProductWriteOnlyRepository : IWriteOnlyRepository<Product, Guid>;