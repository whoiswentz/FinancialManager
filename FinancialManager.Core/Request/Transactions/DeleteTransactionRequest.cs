namespace FinancialManager.Core.Request.Validators.Transactions;

public class DeleteTransactionRequest : BaseRequest
{
    public Guid? Id { get; set; }
}