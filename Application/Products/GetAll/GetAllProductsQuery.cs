using Ardalis.Result;
using Domain.Products;
using MediatR;

namespace Application.Products.GetAll;

public record GetAllProductsQuery() : IRequest<Result<IEnumerable<Product>>>;