using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;

namespace FinancialManager.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IAppEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app
            .MapGet("/{id}", HandleAsync)
            .WithName("Categories: Get")
            .WithSummary("Get Category")
            .Produces<Response<Category>>();
    }

    private static async Task<IResult> HandleAsync(Guid id, ICategoryHandler handler)
    {
        var result = await handler.GetByIdAsync(new GetCategoryByIdRequest
        {
            Id = id
        });

        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}