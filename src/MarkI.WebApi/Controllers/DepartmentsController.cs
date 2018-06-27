using System;
using MarkI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MarkI.WebApi
{
    public class DepartmentsController
    {
        public DepartmentsController()
        {
        }

        public IActionResult Save(Department department)
        {   
            if(department.IsValid())
            return new OkResult(); 
            
            return new BadRequestResult();            
        }
    }
}