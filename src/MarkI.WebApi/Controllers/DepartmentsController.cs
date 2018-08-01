using System;
using System.Net;
using MarkI.Services;
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
            if(!department.IsValid())
            return new BadRequestResult();

            if(_departmentService.Save(department))
            return new OkResult(); 
            
            return new BadRequestResult();            
        }

        [HttpGet]
        public IActionResult Get()
        {   
            try
            {       
                return new OkObjectResult(_departmentService.Get());
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.ServiceUnavailable);
            } 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var departmentResult =  _departmentService.GetById(id);
                return departmentResult != null ? new OkObjectResult(departmentResult) : (IActionResult)new NotFoundObjectResult($"Value {id} not found");
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}