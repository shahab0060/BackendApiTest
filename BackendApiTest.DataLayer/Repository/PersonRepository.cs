using BackendApiTest.Domain.Entities.Person;
using BackendApiTest.Domain.IRepository;

namespace BackendApiTest.DataLayer.Repository
{
    public class PersonRepository : CrudRepository<Person, long>, IPersonRepository
    {

    }
}
