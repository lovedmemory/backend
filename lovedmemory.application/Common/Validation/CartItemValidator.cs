using FluentValidation;
using lovedmemory.domain.Entities;

namespace lovedmemory.application.Common.Validation;
public class CategoryValidator : AbstractValidator<Tribute>
{
    public CategoryValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}
