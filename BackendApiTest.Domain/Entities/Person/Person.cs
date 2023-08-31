using BackendApiTest.Domain.Entities.Common;
using BackendApiTest.Domain.IRepository;
using System.ComponentModel.DataAnnotations;

namespace BackendApiTest.Domain.Entities.Person
{
    public class Person : EntityId<long>, IAggregateRoot
    {
        #region Properties

        [Display(Name = "نام")]
        [MaxLength(250)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required]
        [MaxLength(250)]
        public string Family { get; set; }

        #endregion

        #region methods

        public string GetFullName()
        => $"{this.Name} {this.Family}";

        #endregion

        #region Relations

        public ICollection<Transaction.Transaction> Transactions { get; set; }

        #endregion
    }
}
