using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;

namespace FinancialManager.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IAppEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app
            .MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Creates a new Category")
            .WithDescription("Creates a new category")
            .Produces<Response<Category>>();
    }

    private static async Task<IResult> HandleAsync(CreateCategoryRequest request, ICategoryHandler handler)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}