using Ardalis.Result;
using Domain.Products;
using MediatR;

namespace Application.Products.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<Result<Product>>;