
using MarkI.Domain;
using MarkI.IRepository;

namespace MarkI.Repository.Stub
{
    public class DeparmentsRepositoryTestOk : IDepartments
    {
        public bool Save(Department deparment)
        {
            return true;
        }
    }
}