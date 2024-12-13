using FinancialManager.Api.Data;
using FinancialManager.Core.Handlers;
using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Transactions;
using FinancialManager.Core.Request.Validators.Transactions;
using FinancialManager.Core.Response;
using Microsoft.EntityFrameworkCore;

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
        var transaction = await context.Transactions.FirstOrDefaultAsync(
            x => x.Id == request.Id && x.UserId == request.UserId);
        
        if (transaction is null)
            return new Response<Transaction?>(null, 404, "Transaction not found");
        
        transaction.Amount = request.Amount.GetValueOrDefault();
        transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
        transaction.Title = request.Title;
        transaction.Type = request.Type.GetValueOrDefault();
        
        context.Transactions.Update(transaction);
        await context.SaveChangesAsync();
        
        return new Response<Transaction?>(transaction);
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var transaction = await context.Transactions.FirstOrDefaultAsync(
            x => x.Id == request.Id && x.UserId == request.UserId);

        if (transaction is null)
            return new Response<Transaction?>(null, 404, "Transaction not found");
        
        context.Transactions.Remove(transaction);
        await context.SaveChangesAsync();
            
        return new Response<Transaction?>(transaction);
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        var transaction = await context.Transactions.FirstOrDefaultAsync(
            x => x.Id == request.Id && x.UserId == request.UserId);
        
        return transaction is null 
            ? new Response<Transaction?>(null, 404, "Transaction not found")
            : new Response<Transaction?>(transaction);
    }

    public async Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}