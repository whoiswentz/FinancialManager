using FinancialManager.Core;
using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IAppEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/", HandleAsync)
            .WithName("Categories: GetAll")
            .WithSummary("Get all categories")
            .Produces<PagedResponse<List<Category>?>>();
    }

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        [FromQuery] int pageNumber = Constants.DefaultPageNumber,
        [FromQuery] int pageSize = Constants.DefaultPageSize)
    {
        var result = await handler.GetAllAsync(new GetAllCategoriesRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        });
        return result.IsSuccess
            ? TypedResults.Ok(result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}