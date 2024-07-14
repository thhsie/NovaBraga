namespace Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken = default);

    void Insert(Product product);
}