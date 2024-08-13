namespace FinancialManager.Core.Request.Transactions;

public class GetTransactionByPeriodRequest : PaginatedRequest
{
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}