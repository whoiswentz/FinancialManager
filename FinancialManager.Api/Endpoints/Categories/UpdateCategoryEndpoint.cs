using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;

namespace FinancialManager.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IAppEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app
            .MapPut("/{id}", HandleAsync)
            .WithName("Categories: Update")
            .WithSummary("Update Category")
            .Produces<Response<Category>>();
    }

    private static async Task<IResult> HandleAsync(Guid id, UpdateCategoryRequest request, ICategoryHandler handler)
    {
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}