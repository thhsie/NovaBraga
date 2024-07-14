using FluentValidation;

namespace Application.Products.GetById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();
    }
}