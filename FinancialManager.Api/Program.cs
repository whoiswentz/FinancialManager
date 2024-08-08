using FinancialManager.Api.Data;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Categories;
using FinancialManager.Core.Response;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options => { options.CustomSchemaIds(type => type.FullName); })
    .AddDbContext<AppDbContext>(x => { x.UseSqlServer(connectionString); });
builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app
    .MapPost("/v1/transactions", (CreateCategory request, Handler handler) => { handler.Handle(request); })
    .WithName("Transaction: Create")
    .WithSummary("Creates a new transaction")
    .Produces<Response<Category>>();

app.Run();