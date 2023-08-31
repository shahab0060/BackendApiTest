using BackendApiTest.Core.Mappers;
using BackendApiTest.Core.Services.Interfaces;
using BackendApiTest.Domain.Entities.Person;
using BackendApiTest.Domain.Enums;
using BackendApiTest.Domain.IRepository;
using BackendApiTest.Domain.ViewModels.Person;
using Microsoft.EntityFrameworkCore;

namespace BackendApiTest.Core.Services.Classes
{
    public class PersonService : IPersonService
    {
        #region constructor

        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            this._repository = repository;
        }

        #endregion

        public async Task<List<PersonListDto>> FilterPeople(filterPeopleDto filter)
        {
            IQueryable<Person> query = _repository.GetQuerable();

            #region filter

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(q => EF.Functions.Like(q.Name, $"%{filter.Name}%"));

            if (!string.IsNullOrEmpty(filter.Family))
                query = query.Where(q => EF.Functions.Like(q.Family, $"%{filter.Family}%"));

            #endregion

            query = query.Include(q => q.Transactions);

            return await query.ToDto().ToListAsync();
        }

        public async Task<BaseChangeEntityResult> CreatePerson(CreatePersonDto create)
        {
            Person Person = await create.ToModel();
            await _repository.Add(Person);
            await _repository.SaveChanges();
            return BaseChangeEntityResult.Success;
        }

        public async Task<BaseChangeEntityResult> UpdatePerson(UpdatePersonDto update)
        {
            Person? Person = await _repository.GetAsTracking(update.Id);
            if (Person is null) return BaseChangeEntityResult.NotFound;

            Person = await Person.ToModel(update);
            _repository.Update(Person);

            await _repository.SaveChanges();

            return BaseChangeEntityResult.Success;
        }

        public async Task<UpdatePersonDto?> GetPersonInformation(long PersonId)
        {
            Person? Person = await _repository
                .GetQuerable()
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == PersonId);
            if (Person is null) return null;
            return Person.ToUpdateDto();
        }

        public async Task<BaseChangeEntityResult> DeletePerson(long PersonId)
        {
            Person? Person = await _repository.GetAsTracking(PersonId);
            if (Person is null) return BaseChangeEntityResult.NotFound;

            _repository.Delete(Person);
            await _repository.SaveChanges();

            return BaseChangeEntityResult.Success;
        }

        public async Task<PersonListDto?> GetMaxBuyer()
        => await _repository
            .GetQuerable()
            .OrderByDescending(a => a.Transactions.Sum(t => t.Price))
            .Include(a => a.Transactions)
            .ToDto()
            .FirstOrDefaultAsync();

        public async Task<PersonListDto?> GetMaxBuyer(FilterMaxBuyerDto filter)
        => await _repository
            .GetQuerable()
            .Where(q => q.CreateDate >= filter.FromDate && q.CreateDate <= filter.ToDate)
            .Include(a=>a.Transactions)
            .OrderByDescending(a => a.Transactions.Sum(t => t.Price))
            .ToDto()
            .FirstOrDefaultAsync();

    }
}

