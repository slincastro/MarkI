using System;
using MarkI.IRepository;

namespace MarkI.Department
{
    public class DepartmentService
    {
        private IDepartments repository;

        public DepartmentService(IDepartments repository)
        {
            this.repository = repository;
        }

        public bool Save(MarkI.Domain.Department currentDepartment)
        {
            return repository.Save(currentDepartment);
        }
    }
}