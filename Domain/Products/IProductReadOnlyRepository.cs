using Domain.SharedKernel;

namespace Domain.Products;

public interface IProductReadOnlyRepository : IReadOnlyRepository<Product, Guid>;