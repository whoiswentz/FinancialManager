using FinancialManager.Core.Request.Categories;
using FluentValidation;

namespace FinancialManager.Core.Request.Validators;

public class DeleteCategoryRequestValidator : BaseRequestValidator<DeleteCategoryRequest>
{
    public DeleteCategoryRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}