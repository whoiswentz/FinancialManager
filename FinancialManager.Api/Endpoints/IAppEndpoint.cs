namespace FinancialManager.Api.Endpoints;

public interface IAppEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}