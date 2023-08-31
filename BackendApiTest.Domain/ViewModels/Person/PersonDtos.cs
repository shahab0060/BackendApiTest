using BackendApiTest.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace BackendApiTest.Domain.ViewModels.Person
{
    public class filterPeopleDto
    {
        public string? Name { get; set; }

        public string? Family { get; set; }
    }

    public class FilterMaxBuyerDto
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }

    public class PersonListDto : BaseListDto<long>
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public int TotalTransactionPrice { get; set; }
    }

    public class BaseChangePersonDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Family { get; set; }
    }

    public class CreatePersonDto : BaseChangePersonDto
    {
       
    }

    public class UpdatePersonDto : BaseChangePersonDto
    {
        public long Id { get; set; }
    }

}
