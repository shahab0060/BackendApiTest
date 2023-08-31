using BackendApiTest.Domain.Entities.Transaction;
using BackendApiTest.Domain.IRepository;

namespace BackendApiTest.DataLayer.Repository
{
    public class TransactionRepository : CrudRepository<Transaction, long>, ITransactionRepository
    {

    }
}
