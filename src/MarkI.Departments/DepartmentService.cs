using System;
using MarkI.IRepository;
using MarkI.Domain;

namespace MarkI.Departments
{
    public class DepartmentService
    {
        private IDepartments repository;

        public DepartmentService(IDepartments repository)
        {
            this.repository = repository;
        }

        public bool Save(Department currentDepartment)
        {
            return repository.Save(currentDepartment);
        }
    }
}