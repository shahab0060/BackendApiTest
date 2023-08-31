using BackendApiTest.Domain.Entities.Transaction;
using BackendApiTest.Domain.ViewModels.Transaction;

namespace BackendApiTest.Core.Mappers
{
    public static class TransactionMappers
    {
        public static TransactionListDto ToDto(this Transaction a)
        => new TransactionListDto()
        {
            Id = a.Id,
            PersonId = a.PersonId,
            Price = a.Price,
            PersonFullName = a.Person.GetFullName()
        };

        public static UpdateTransactionDto ToUpdateDto(this Transaction a)
           => new UpdateTransactionDto()
           {
               Id = a.Id,
               Price = a.Price
           };

        public static IQueryable<TransactionListDto> ToDto(this IQueryable<Transaction> People)
            => People.Select(a => a.ToDto());

        public static async Task<Transaction> ToModel(this CreateTransactionDto create)
            => new Transaction()
            {
                Price = create.Price,
                PersonId = create.PersonId
            };
        public static async Task<Transaction> ToModel(this Transaction Transaction, UpdateTransactionDto update)
        {
            Transaction.Price = update.Price;
            return Transaction;
        }
    }
}
