
using MarkI.Domain;
using MarkI.IRepository;

namespace MarkI.Repository.Stub
{
    public class DeparmentRepositoryTestFalse : IDepartments
    {
        public bool Save(Department deparment)
        {
            return false;
        }
    }
}