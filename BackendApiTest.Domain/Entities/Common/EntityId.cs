using BackendApiTest.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace BackendApiTest.Domain.Entities.Common
{
    public class EntityId<T> where T : struct
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LatestEditDate { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int EditCounts { get; set; }

        public bool IsDelete { get; set; }

    }

}
