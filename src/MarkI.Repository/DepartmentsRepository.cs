using MarkI.Domain;

namespace MarkI.Repository
{
    public class DepartmentsRepository : RepositoryBase<Department>
    {
        public DepartmentsRepository(ApplicationContext aplicationContext) : base(aplicationContext)
        {
        }
    }
}