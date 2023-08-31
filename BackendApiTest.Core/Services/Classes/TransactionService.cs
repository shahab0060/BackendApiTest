using BackendApiTest.Core.Mappers;
using BackendApiTest.Core.Services.Interfaces;
using BackendApiTest.Domain.Entities.Transaction;
using BackendApiTest.Domain.Enums;
using BackendApiTest.Domain.IRepository;
using BackendApiTest.Domain.ViewModels.Transaction;
using Microsoft.EntityFrameworkCore;

namespace BackendApiTest.Core.Services.Classes
{
    public class TransactionService : ITransactionService
    {
        #region constructor

        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            this._repository = repository;
        }

        #endregion

        public async Task<List<TransactionListDto>> FilterTransactions(filterTransactionsDto filter)
        {
            IQueryable<Transaction> query = _repository.GetQuerable();

            #region filter

            if (filter.PersonId > 0)
                query = query.Where(q => q.PersonId == filter.PersonId);

            if (filter.FromDate is not null)
                query = query.Where(q => q.CreateDate >=filter.FromDate);

            if (filter.ToDate is not null)
                query = query.Where(q => q.CreateDate <= filter.ToDate);

            #endregion

            query = query.Include(q => q.Person);

            return await query.ToDto().ToListAsync();
        }

        public async Task<BaseChangeEntityResult> CreateTransaction(CreateTransactionDto create)
        {
            Transaction Transaction = await create.ToModel();
            await _repository.Add(Transaction);
            await _repository.SaveChanges();
            return BaseChangeEntityResult.Success;
        }

        public async Task<BaseChangeEntityResult> UpdateTransaction(UpdateTransactionDto update)
        {
            Transaction? Transaction = await _repository.GetAsTracking(update.Id);
            if (Transaction is null) return BaseChangeEntityResult.NotFound;

            Transaction = await Transaction.ToModel(update);
            _repository.Update(Transaction);

            await _repository.SaveChanges();

            return BaseChangeEntityResult.Success;
        }

        public async Task<UpdateTransactionDto?> GetTransactionInformation(long TransactionId)
        {
            Transaction? Transaction = await _repository
                .GetQuerable()
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == TransactionId);
            if (Transaction is null) return null;
            return Transaction.ToUpdateDto();
        }

        public async Task<BaseChangeEntityResult> DeleteTransaction(long TransactionId)
        {
            Transaction? Transaction = await _repository.GetAsTracking(TransactionId);
            if (Transaction is null) return BaseChangeEntityResult.NotFound;

            _repository.Delete(Transaction);
            await _repository.SaveChanges();

            return BaseChangeEntityResult.Success;
        }

    }
}

