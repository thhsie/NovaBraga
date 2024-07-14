using Application.Products.GetById;
using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using Contracts.Pricing;
using Domain.Pricing;
using FluentValidation;
using MediatR;

namespace Application.Pricing.GetByProductId;

public class GetPricingByProductIdQueryHandler(
    IValidator<GetPricingByProductIdQuery> validator,
    IPricingReadOnlyRepository pricingRepository,
    IMapper mapper) : IRequestHandler<GetPricingByProductIdQuery, Result<GetPricingByProductIdResponse>>
{
    public async Task<Result<GetPricingByProductIdResponse>> Handle(
        GetPricingByProductIdQuery request, CancellationToken cancellationToken)
    {
        // Validate
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result<GetPricingByProductIdResponse>.Invalid(validationResult.AsErrors());
        }

        // Instantiate
        var prices = await pricingRepository.GetByProductIdAsync(request.ProductId, cancellationToken);
        var productPrices = mapper.Map<IEnumerable<ProductPrice>>(prices.OrderBy(price => price.ProductId));

        // Return
        return Result<GetPricingByProductIdResponse>.Success(new GetPricingByProductIdResponse(productPrices));
    }
}