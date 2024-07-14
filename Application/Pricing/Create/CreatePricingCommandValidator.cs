using FluentValidation;

namespace Application.Pricing.Create;

public class CreatePricingCommandValidator : AbstractValidator<CreatePricingCommand>
{
    public CreatePricingCommandValidator()
    {
        RuleFor(command => command.CreatePricingRequest.ProductId)
            .NotEmpty();
        RuleFor(command => command.CreatePricingRequest.Location)
            .NotEmpty();
        RuleFor(command => command.CreatePricingRequest.CalculatedPrice)
            .NotEmpty();
    }
}