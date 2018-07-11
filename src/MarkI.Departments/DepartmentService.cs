using System;
using MarkI.IRepository;
using MarkI.Domain;
using System.Collections.Generic;

namespace MarkI.Departments
{
    public class DepartmentService
    {
        private IDepartments _repository;

        public DepartmentService(IDepartments repository)
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
            catch(Exception)
            {
                return false;
            } 
        }

        public List<Department> Get()
        {
            try
            {
                return _repository.Get();
            }
            catch(Exception)
            {
                throw new ArgumentException("We are having problems, contact the administrator. ");
            }
        }
    }
}