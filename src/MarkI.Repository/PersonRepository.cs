using MarkI.Domain;
using MarkI.IRepository;

namespace MarkI.Repository
{
    public class PersonRepository: RepositoryBase<Person>, IPerson
    {
        public PersonRepository(ApplicationContext aplicationContext) : base(aplicationContext)
        {
        }
    }
}