using FluentValidation;

namespace Application.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.CreateProductRequest.Title)
            .NotEmpty();

        RuleFor(command => command.CreateProductRequest.Category)
            .NotEmpty();

        RuleFor(command => command.CreateProductRequest.YearMade)
            .NotNull();
    }
}