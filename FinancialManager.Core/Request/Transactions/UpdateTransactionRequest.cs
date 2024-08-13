using FinancialManager.Core.Enums;

namespace FinancialManager.Core.Request.Transactions;

public class UpdateTransactionRequest : BaseRequest
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public TransactionType? Type { get; set; }
    public decimal? Amount { get; set; }
    public Guid? CategoryId { get; set; }
    public DateTime? PaidOrReceivedAt { get; set; }
}