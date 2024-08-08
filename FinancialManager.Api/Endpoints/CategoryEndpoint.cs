using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;

namespace FinancialManager.Api.Endpoints;

public class CategoryEndpoint : IAppEndpoint
{
    public void MapRoutes(IEndpointRouteBuilder routes)
    {
        routes
            .MapPost("/v1/categories",
                async (CreateCategoryRequest request, ICategoryHandler handler) =>
                    await handler.CreateAsync(request))
            .WithName("Categories: Create")
            .WithSummary("Creates a new Category")
            .Produces<Response<Category>>();
        
        routes
            .MapPut("/v1/categories/{id}",
                async (Guid id, UpdateCategoryRequest request, ICategoryHandler handler) =>
                {
                    request.Id = id;
                    await handler.UpdateAsync(request);
                })
            .WithName("Categories: Update")
            .WithSummary("Update Category")
            .Produces<Response<Category>>();
        
        routes
            .MapDelete("/v1/categories/{id}",
                async (Guid id, DeleteCategoryRequest request, ICategoryHandler handler) =>
                {
                    request.Id = id;
                    await handler.DeleteAsync(request);
                })
            .WithName("Categories: Delete")
            .WithSummary("Delete Category")
            .Produces<Response<Category>>();
    }
}