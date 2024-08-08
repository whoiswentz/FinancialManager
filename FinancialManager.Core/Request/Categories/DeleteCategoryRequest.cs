namespace FinancialManager.Core.Request.Categories;

public class DeleteCategoryRequest : BaseRequest
{
    public Guid Id { get; set; }
}