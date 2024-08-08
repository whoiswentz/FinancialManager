namespace FinancialManager.Core.Request;

public class CreateCategory : BaseRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}