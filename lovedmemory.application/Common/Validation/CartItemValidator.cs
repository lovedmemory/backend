using FluentValidation;
using lovedmemory.Domain.Entities;

namespace lovedmemory.Application.Common.Validation;
public class CategoryValidator : AbstractValidator<Tribute>
{
    public CategoryValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}
