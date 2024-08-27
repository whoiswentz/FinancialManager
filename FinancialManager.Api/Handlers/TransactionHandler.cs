using FinancialManager.Api.Data;
using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Transactions;
using FinancialManager.Core.Request.Validators.Transactions;
using FinancialManager.Core.Response;

namespace FinancialManager.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        var transaction = new Transaction
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Amount = request.Amount,
            PaidOrReceivedAt = request.PaidOrReceivedAt,
            Title = request.Title,
            Type = request.Type
        };
        await context.Transactions.AddAsync(transaction);
        await context.SaveChangesAsync();

        return new Response<Transaction?>(transaction, 201, "Transaction created");
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}