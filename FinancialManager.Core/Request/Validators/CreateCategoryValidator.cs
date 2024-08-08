using FluentValidation;

namespace FinancialManager.Core.Request.Validators;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategory>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(80)
            .WithMessage("Title must be present");
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Description must be present");
    }
}