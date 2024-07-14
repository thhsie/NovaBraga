using Ardalis.Result;
using Contracts.Pricing;
using MediatR;

namespace Application.Pricing.GetByProductId;

public record GetPricingByProductIdQuery(Guid ProductId) : IRequest<Result<GetPricingByProductIdResponse>>;