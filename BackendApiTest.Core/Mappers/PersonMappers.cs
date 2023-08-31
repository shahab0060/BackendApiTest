using BackendApiTest.Domain.Entities.Person;
using BackendApiTest.Domain.ViewModels.Person;

namespace BackendApiTest.Core.Mappers
{
    public static class PersonMappers
    {
        public static PersonListDto ToDto(this Person a)
        => new PersonListDto()
        {
            Id = a.Id,
            Family = a.Family,
            Name = a.Name,
            TotalTransactionPrice = a.Transactions.Sum(t=>t.Price)
        };

        public static UpdatePersonDto ToUpdateDto(this Person a)
           => new UpdatePersonDto()
           {
               Id = a.Id,
               Name = a.Name,
               Family = a.Family
           };

        public static CreatePersonDto ToCreateDto(this Person a)
          => new CreatePersonDto()
          {
              Family = a.Family,
              Name = a.Name,
          };

        public static IQueryable<PersonListDto> ToDto(this IQueryable<Person> People)
            => People.Select(a => a.ToDto());

        public static async Task<Person> ToModel(this CreatePersonDto create)
            => new Person()
            {
                Name = create.Name,
                Family = create.Family
            };
        public static async Task<Person> ToModel(this Person Person, UpdatePersonDto update)
        {
            Person.Name = update.Name;
            Person.Family = update.Family;
            return Person;
        }
    }
}
