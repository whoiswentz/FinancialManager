using FinancialManager.Core.Request.Categories;
using FluentValidation;

namespace FinancialManager.Core.Request.Validators;

public class CreateCategoryRequestValidator : BaseRequestValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(80)
            .WithMessage("Title must be present");
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Description must be present");
    }
}