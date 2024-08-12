using FinancialManager.Api;
using FinancialManager.Api.Data;
using FinancialManager.Api.Endpoints;
using FinancialManager.Api.Handlers;
using FinancialManager.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options => { options.CustomSchemaIds(type => type.FullName); })
    .AddDbContext<AppDbContext>(x => { x.UseSqlServer(connectionString); })
    .AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app.MapEndpoints();

app.Run();