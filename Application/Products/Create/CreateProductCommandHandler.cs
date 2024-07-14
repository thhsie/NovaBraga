using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Contracts.Products;
using Domain.Primitives;
using Domain.Products;
using FluentValidation;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler(
    IValidator<CreateProductCommand> validator,
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, Result<CreatedProductResponse>>
{
    public async Task<Result<CreatedProductResponse>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        // Validate
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result<CreatedProductResponse>.Invalid(validationResult.AsErrors());
        }

        // Instantiate
        var product = Product.Create(
            request.CreateProductRequest.Title,
            request.CreateProductRequest.Description,
            request.CreateProductRequest.Category,
            request.CreateProductRequest.YearMade);

        // Insert
        productRepository.Insert(product);
        await unitOfWork.SaveChangesAsync();

        return Result<CreatedProductResponse>.Success(
            new CreatedProductResponse(product.Id), "Product successfully created.");
    }
}