using FinancialManager.Api.Data;
using FinancialManager.Core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options => 
    {
        options.CustomSchemaIds(type => type.FullName);
    }).AddDbContext<AppDbContext>(x =>
    {
        x.UseSqlServer(connectionString);
    });
builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app
    .MapPost("/v1/transactions", (Request request, Handler handler) =>
    {
        handler.Handle(request);
    })
    .WithName("Transaction: Create")
    .WithSummary("Creates a new transaction")
    .Produces<Response>();

app.Run();

public class Handler(AppDbContext context)
{
    public Response Handle(Request request)
    {
        var category = context.Categories.Add(new Category
        {
            Title = request.Title,
            Description = request.Description
        }).Entity;
        context.SaveChanges();
        
        return new Response
        {
            Id = category.Id,
            Title = category.Title,
            Description = category.Description
        };
    }
}

public record Request
{
    
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public record Response
{
    public Guid Id { get; set; }
    public string? Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
}