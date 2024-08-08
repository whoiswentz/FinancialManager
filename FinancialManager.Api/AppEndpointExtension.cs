using System.Reflection;
using FinancialManager.Api.Endpoints;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FinancialManager.Api;

public static class AppEndpointExtension
{
    public static IServiceCollection AddAppEndpoints(this IServiceCollection services)
    {
        var servicesDescriptors = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t is { IsAbstract: false, IsInterface: false } && t.IsAssignableTo(typeof(IAppEndpoint)))
            .Select(t => ServiceDescriptor.Transient(typeof(IAppEndpoint), t));

        services.TryAddEnumerable(servicesDescriptors);

        return services;
    }

    public static IApplicationBuilder RegisterMinimalEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IAppEndpoint>>();
        foreach (var endpoint in endpoints) endpoint.MapRoutes(app);
        return app;
    }
}