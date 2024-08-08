namespace FinancialManager.Core.Request.Categories;

public class UpdateCategoryRequest : BaseRequest
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}