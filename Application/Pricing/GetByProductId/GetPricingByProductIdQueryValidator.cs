using FluentValidation;

namespace Application.Pricing.GetByProductId;

public class GetPricingByProductIdQueryValidator : AbstractValidator<GetPricingByProductIdQuery>
{
    public GetPricingByProductIdQueryValidator()
    {
        RuleFor(command => command.ProductId)
            .NotEmpty();
    }
}