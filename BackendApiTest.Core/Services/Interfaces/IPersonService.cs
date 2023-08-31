using BackendApiTest.Domain.Enums;
using BackendApiTest.Domain.ViewModels.Person;

namespace BackendApiTest.Core.Services.Interfaces
{
    public interface IPersonService : IService
    {
        Task<List<PersonListDto>> FilterPeople(filterPeopleDto filter);
        Task<BaseChangeEntityResult> CreatePerson(CreatePersonDto create);
        Task<BaseChangeEntityResult> UpdatePerson(UpdatePersonDto update);
        Task<UpdatePersonDto?> GetPersonInformation(long PersonId);
        Task<BaseChangeEntityResult> DeletePerson(long PersonId);
        Task<PersonListDto?> GetMaxBuyer();
        Task<PersonListDto?> GetMaxBuyer(FilterMaxBuyerDto filter);
    }
}
