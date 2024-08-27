using FinancialManager.Core.Enums;

namespace FinancialManager.Core.Request.Transactions;

public class CreateTransactionRequest : BaseRequest
{
    public string Title { get; set; } = null!;
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime? PaidOrReceivedAt { get; set; }
}