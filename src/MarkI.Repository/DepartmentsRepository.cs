using MarkI.Domain;
using MarkI.IRepository;

namespace MarkI.Repository
{
    public class DepartmentsRepository : RepositoryBase<Department>, IDepartments
    {
        public DepartmentsRepository(ApplicationContext aplicationContext) : base(aplicationContext)
        {
        }
    }
}