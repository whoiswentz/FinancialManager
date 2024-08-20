using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Transactions;
using FinancialManager.Core.Response;

namespace FinancialManager.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IAppEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HandleAsync)
            .WithName("Transaction: Create")
            .WithSummary("Create a new transaction")
            .WithDescription("Creates a new transaction")
            .Produces<Response<Transaction>>();
    }

    private static async Task<IResult> HandleAsync(
        CreateTransactionRequest request,
        ITransactionHandler handler)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result.Data)
            : TypedResults.BadRequest(result.Data);
    }
}