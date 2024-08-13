using FinancialManager.Api.Endpoints.Categories;
using FinancialManager.Core.Request.Categories;

namespace FinancialManager.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/v1");

        endpoints.MapGroup("/categories")
            .WithTags("Categories")
            // .RequireAuthorization()
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>()
            .MapEndpoint<GetCategoryByIdEndpoint>()
            .MapEndpoint<GetAllCategoriesEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<T>(this IEndpointRouteBuilder app)
        where T : IAppEndpoint
    {
        T.Map(app);
        return app;
    }
}