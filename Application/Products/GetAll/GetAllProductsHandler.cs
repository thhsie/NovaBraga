using Ardalis.Result;
using Domain.Products;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Products.GetAll;

public class GetAllProductsHandler(
    IProductRepository productRepository
    ) : IRequestHandler<GetAllProductsQuery, Result<IEnumerable<Product>>>
{
    public async Task<Result<IEnumerable<Product>>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        return Result<IEnumerable<Product>>.Success(await productRepository.GetAll(cancellationToken));
    }
}