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

        public DepartmentsController(IDepartments deparmentRepository)
        {
            _departmentService = new DepartmentService(deparmentRepository);
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody]Department department)
        {   
            if(department.IsValid())
            return _departmentService.Save(department) ?  new OkResult() : throw new ArgumentException("We Cant save department"); 
            
            return new BadRequestResult();            
        }
    }
}