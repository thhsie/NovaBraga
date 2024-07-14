using Ardalis.Result;
using Contracts.Products;
using MediatR;

namespace Application.Products.Create;

public sealed record CreateProductCommand(
    CreateProductRequest CreateProductRequest
    ) : IRequest<Result<CreatedProductResponse>>;