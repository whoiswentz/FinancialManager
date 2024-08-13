namespace FinancialManager.Core.Request.Validators.Transactions;

public class GetTransactionByIdRequest : BaseRequest
{
    public Guid? Id { get; set; }
}