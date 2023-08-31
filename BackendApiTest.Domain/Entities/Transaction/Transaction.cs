using BackendApiTest.Domain.Entities.Common;
using BackendApiTest.Domain.IRepository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApiTest.Domain.Entities.Transaction
{
    public class Transaction : EntityId<long>, IAggregateRoot
    {
        #region properties

        public long PersonId { get; set; }

        [Display(Name = ("قیمت"))]
        public int Price { get; set; }

        #endregion

        #region relations

        [ForeignKey(nameof(PersonId))]
        public Person.Person Person { get; set; }

        #endregion
    }
}
