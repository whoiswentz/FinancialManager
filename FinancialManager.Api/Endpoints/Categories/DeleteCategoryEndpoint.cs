using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;

namespace FinancialManager.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IAppEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app
            .MapDelete("/{id}", HandleAsync)
            .WithName("Categories: Delete")
            .WithSummary("Delete Category")
            .Produces<Response<Category>>();
    }

    private static async Task<IResult> HandleAsync(Guid id, ICategoryHandler handler)
    {
        var result = await handler.DeleteAsync(new DeleteCategoryRequest
        {
            Id = id
        });
        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}