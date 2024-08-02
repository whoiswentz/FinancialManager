var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});
builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app
    .MapPost("/v1/transactions", (Request request, Handler handler) =>
    {
        handler.Handle(request);
    })
    .WithName("Transaction: Create")
    .WithSummary("Creates a new transaction")
    .Produces<Response>();

app.Run();

public class Handler
{
    public Response Handle(Request request)
    {
        return new Response { Message = "test" };
    }
}

public record Request
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime PaidOrReceivedAt { get; set; }
    public decimal Amount { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}

public record Response
{
    public string Message { set; get; }
}