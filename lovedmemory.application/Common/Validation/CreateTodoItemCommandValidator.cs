using FluentValidation;
using lovedmemory.domain.Entities;

namespace lovedmemory.application.Common.Validation;

public class ProductValidator : AbstractValidator<Tribute>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}
