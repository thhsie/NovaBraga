using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Contracts.Pricing;
using Domain.Pricing;
using Domain.Primitives;
using FluentValidation;
using MediatR;

namespace Application.Pricing.Create;

public class CreatePricingCommandHandler(
    IValidator<CreatePricingCommand> validator,
    IPricingRepository pricingRepository,
    IDateTimeProvider dateTimeProvider,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePricingCommand, Result<CreatedPricingResponse>>
{
    public async Task<Result<CreatedPricingResponse>> Handle(
        CreatePricingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result<CreatedPricingResponse>.Invalid(validationResult.AsErrors());
        }

        // Instantiate
        var pricing = Domain.Pricing.Pricing.Create(
            request.CreatePricingRequest.ProductId,
            request.CreatePricingRequest.Location,
            request.CreatePricingRequest.CalculatedPrice,
            dateTimeProvider.UtcNow
        );

        // Insert
        pricingRepository.Insert(pricing);
        await unitOfWork.SaveChangesAsync();

        return Result<CreatedPricingResponse>.Success(new CreatedPricingResponse(pricing.Id),
            "Pricing successfully created.");
    }
}