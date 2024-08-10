using System.Text.Json.Serialization;

namespace FinancialManager.Core.Response;

public class PagedResponse<T> : Response<T>
{
    [JsonConstructor]
    public PagedResponse(
        T? data,
        int totalCount,
        int currentPage = Constants.DefaultCurrentPage,
        int pageSize = Constants.DefaultPageSize)
        : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedResponse(
        T? data,
        int code = Constants.DefaultHttpCode)
        : base(data, code)
    {
    }

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}