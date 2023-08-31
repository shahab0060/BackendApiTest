using BackendApiTest.Domain.Entities.Transaction;

namespace BackendApiTest.Domain.IRepository
{
    public interface ITransactionRepository : IRepository,
        IReadRepository<Transaction, long>,
        IWriteRepository<Transaction, long>,
        IDeleteRepository<Transaction, long>
    {

    }
}
