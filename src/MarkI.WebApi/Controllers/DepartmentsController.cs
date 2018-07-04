using System;
using MarkI.Departments;
using MarkI.Domain;
using MarkI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MarkI.WebApi
{
    [Route("api/[controller]")]
    public class DepartmentsController : Controller
    {
        private DepartmentService _departmentService;

        public DepartmentsController(IRepositoryBase<Department> deparmentRepository)
        {
            _departmentService = new DepartmentService(deparmentRepository);
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody]Department department)
        {   
            if(!department.IsValid())
            return new BadRequestResult();

            if(_departmentService.Save(department))
            return new OkResult(); 
            
            return new BadRequestResult();            
        }
    }
}