using Ardalis.Result;
using Contracts.Pricing;
using MediatR;

namespace Application.Pricing.Create;

public record CreatePricingCommand(CreatePricingRequest CreatePricingRequest) 
    : IRequest<Result<CreatedPricingResponse>>;