using FinancialManager.Core.Enums;

namespace FinancialManager.Core.Models;

public class Transaction
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime PaidOrReceivedAt { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public Guid UserId { get; set; }
}