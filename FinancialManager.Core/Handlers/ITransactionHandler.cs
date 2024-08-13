using FinancialManager.Core.Models;
using FinancialManager.Core.Request.Transactions;
using FinancialManager.Core.Request.Validators.Transactions;
using FinancialManager.Core.Response;

namespace FinancialManager.Core.Handlers;

public interface ITransactionHandler
{
    Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
    Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
    Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
    Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionByPeriodRequest request);
}