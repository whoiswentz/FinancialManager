using FinancialManager.Core.Request.Categories;
using FluentValidation;

namespace FinancialManager.Core.Request.Validators;

public class GetCategoryByIdRequestValidator : BaseRequestValidator<GetCategoryByIdRequest>
{
    public GetCategoryByIdRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}