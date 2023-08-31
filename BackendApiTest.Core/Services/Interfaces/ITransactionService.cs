using BackendApiTest.Domain.Enums;
using BackendApiTest.Domain.ViewModels.Transaction;

namespace BackendApiTest.Core.Services.Interfaces
{
    public interface ITransactionService : IService
    {
        Task<List<TransactionListDto>> FilterTransactions(filterTransactionsDto filter);
        Task<BaseChangeEntityResult> CreateTransaction(CreateTransactionDto create);
        Task<BaseChangeEntityResult> UpdateTransaction(UpdateTransactionDto update);
        Task<UpdateTransactionDto?> GetTransactionInformation(long TransactionId);
        Task<BaseChangeEntityResult> DeleteTransaction(long TransactionId);
    }
}
