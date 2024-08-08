using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Endpoints;

public class CategoryEndpoint : IAppEndpoint
{
    public void MapRoutes(IEndpointRouteBuilder endpoints)
    {
        endpoints
            .MapPost("/v1/categories",
                async ([FromBody] CreateCategoryRequest request, ICategoryHandler handler) =>
                await handler.CreateAsync(request))
            .WithName("Categories: Create")
            .WithSummary("Creates a new Category")
            .Produces<Response<Category>>();

        endpoints
            .MapPut("/v1/categories/{id}",
                async (Guid id, [FromBody] UpdateCategoryRequest request, ICategoryHandler handler) =>
                {
                    request.Id = id;
                    return await handler.UpdateAsync(request);
                })
            .WithName("Categories: Update")
            .WithSummary("Update Category")
            .Produces<Response<Category>>();

        endpoints
            .MapDelete("/v1/categories/{id}",
                async (Guid id, [FromBody] DeleteCategoryRequest request, ICategoryHandler handler) =>
                {
                    request.Id = id;
                    return await handler.DeleteAsync(request);
                })
            .WithName("Categories: Delete")
            .WithSummary("Delete Category")
            .Produces<Response<Category>>();

        endpoints
            .MapGet("/v1/categories/{id}",
                async (Guid id, ICategoryHandler handler) => await handler.GetByIdAsync(new GetCategoryByIdRequest
                {
                    Id = id
                }))
            .WithName("Categories: Get")
            .WithSummary("Get Category")
            .Produces<Response<Category>>();
    }
}