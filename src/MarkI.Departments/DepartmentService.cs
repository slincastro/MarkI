using System;
using MarkI.IRepository;
using MarkI.Domain;
using System.Collections.Generic;

namespace MarkI.Departments
{
    public class DepartmentService
    {
        private IRepositoryBase<Department> _repository;

        public DepartmentService(IRepositoryBase<Department> repository)
        {
            this._repository = repository;
        }

        public bool Save(Department currentDepartment)
        {
            try
            {
                var result = _repository.Add(currentDepartment);
                return result;
            }
            catch(Exception ex)
            {
                return false;
            } 
        }

        public List<Department> Get()
        {
            return _repository.Get();
        }
    }
}