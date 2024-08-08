namespace FinancialManager.Core.Request.Categories;

public class CreateCategoryRequest : BaseRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}