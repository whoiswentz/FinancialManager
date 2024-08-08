using FluentValidation;

namespace FinancialManager.Core.Request.Validators;

public class BaseRequestValidator<T> : AbstractValidator<T>
    where T : BaseRequest
{
    protected BaseRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}