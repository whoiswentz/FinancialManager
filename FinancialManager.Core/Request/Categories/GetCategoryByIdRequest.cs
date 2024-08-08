namespace FinancialManager.Core.Request.Categories;

public class GetCategoryByIdRequest : BaseRequest
{
    public Guid? Id { get; set; }
}