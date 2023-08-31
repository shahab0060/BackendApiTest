using BackendApiTest.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace BackendApiTest.Domain.ViewModels.Transaction
{
    public class filterTransactionsDto
    {
        public long? PersonId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }

    public class TransactionListDto : BaseListDto<long>
    {
        public long PersonId { get; set; }

        public string PersonFullName { get; set; }

        public int Price { get; set; }
    }

    public class BaseChangeTransactionDto
    {
        [Required]
        public int Price { get; set; }
    }

    public class CreateTransactionDto : BaseChangeTransactionDto
    {
        [Required]
        public long PersonId { get; set; }
    }

    public class UpdateTransactionDto : BaseChangeTransactionDto
    {
        public long Id { get; set; }
    }

}
