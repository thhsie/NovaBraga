using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Domain.Products;
using FluentValidation;
using MediatR;

namespace Application.Products.GetById;

public class GetProductByIdQueryHandler(
    IValidator<GetProductByIdQuery> validator,
    IProductRepository productRepository
    ) : IRequestHandler<GetProductByIdQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Validate
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result<Product>.Invalid(validationResult.AsErrors());
        }

        // Instantiate
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);

        // Return
        return product is null ? 
            Result<Product>.NotFound($"No product found with Id: {request.Id}") 
            : Result<Product>.Success(product);
    }
}