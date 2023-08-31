using BackendApiTest.Domain.Entities.Person;

namespace BackendApiTest.Domain.IRepository
{
    public interface IPersonRepository : IRepository,
        IReadRepository<Person, long>,
        IWriteRepository<Person, long>,
        IDeleteRepository<Person, long>
    {

    }
}
