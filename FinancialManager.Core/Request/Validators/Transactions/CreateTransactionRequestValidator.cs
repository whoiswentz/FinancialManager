using FinancialManager.Core.Enums;
using FluentValidation;
using FinancialManager.Core.Request.Transactions;


namespace FinancialManager.Core.Request.Validators.Transactions;

public class CreateTransactionRequestValidator : BaseRequestValidator<CreateTransactionRequest>
{
    public CreateTransactionRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(80)
            .WithMessage("Title must be present");
        RuleFor(x => x.Type)
            .IsInEnum();
        RuleFor(x => x.CategoryId)
            .NotEmpty();
        RuleFor(x => x.PaidOrReceivedAt)
            .NotEmpty();
        
    }
}