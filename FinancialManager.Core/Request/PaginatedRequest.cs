namespace FinancialManager.Core.Request;

public abstract class PaginatedRequest : BaseRequest
{
    public int PageNumber { get; set; } = Constants.DefaultPageNumber;
    public int PageSize { get; set; } = Constants.DefaultPageNumber;
}