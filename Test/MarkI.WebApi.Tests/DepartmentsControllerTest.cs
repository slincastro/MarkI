using MarkI.Domain;
using MarkI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace MarkI.WebApi.Tests
{
    public class DepartmentsControllerTest
    {
        private Mock<IDepartments> _mockRepository;
        private DepartmentsController _departmentController;

        public DepartmentsControllerTest()
        {
            _mockRepository = new Mock<IDepartments>();
            
            _departmentController = new DepartmentsController(_mockRepository.Object);
        }

        [Fact]
        public void ShouldReturn200WhenSendValidDepertment()
        {
            var department = new Department("dep001",1,"Wilmer Huge Calero");
            _mockRepository.Setup(repo => repo.Add(department)).Returns(true);

            var currentResponse = _departmentController.Save(department);

            Assert.IsType<OkResult>(currentResponse);
        }

        [Fact]
        public void ShouldReturn400WhenSendInvalidDepartment()
        {            
            var invalidDepartment = new Department(string.Empty,0,string.Empty);

            var currentResponse = _departmentController.Save(invalidDepartment);

            Assert.IsType<BadRequestResult>(currentResponse);
        }

        [Fact]
        public void ShouldReturn400WhenThrowException()
        {            
            var invalidDepartment = new Department(string.Empty,0,string.Empty);

            _mockRepository.Setup(repo => repo.Add(invalidDepartment)).Throws(new InvalidOperationException());
            var currentResponse = _departmentController.Save(invalidDepartment);

            Assert.IsType<BadRequestResult>(currentResponse);
        }
        
        [Fact]
        public void ShouldCallDepartmentsServicesWhenISendValidObject()
        {
            var currentDepartment = new Department("dep001",1,"Wilmer Kaviedes");
            _mockRepository.Setup(repo => repo.Add(currentDepartment)).Returns(true);
            var currentResponse = _departmentController.Save(currentDepartment);

            _mockRepository.Verify(f =>  f.Add(currentDepartment));

        }

        [Fact]
        public void ShouldBeAControllerClass()
        {
           var classParent = typeof(DepartmentsController).BaseType.Name;
            const string ExpectedParentType = "Controller";
            Assert.Equal(ExpectedParentType, classParent);
        }

        [Fact]
        public void ShouldHaveRouteAttributeInClass()
        {
            var classAttributes = typeof(DepartmentsController).GetCustomAttributes(typeof(RouteAttribute),false).FirstOrDefault();
 
            Assert.IsType<RouteAttribute>(classAttributes);
        }

        [Fact]
        public void ShouldHaveHttpPostAttributeInLoginMethod()
        {
            MethodBase method = typeof(DepartmentsController).GetMethod("Save");
            var mathodAttributes = method.GetCustomAttributes(typeof(HttpPostAttribute),false).FirstOrDefault();
 
            Assert.IsType<HttpPostAttribute>(mathodAttributes);
        }

        [Fact]
        public void ShouldBeFromBodyParam()
        {
            MethodBase method = typeof(DepartmentsController).GetMethod("Save");

            var parameters = method.GetParameters();
            var attributesParameters= parameters[0].GetCustomAttributes(typeof(FromBodyAttribute),false);
            
            Assert.True(attributesParameters.Length > 0);
        }

        [Fact]
        public void ShouldReturn200WithListOfDepartmentsWhenCallGet()
        {
            var departments = new List<Department>{ new Department("dep001",1,"FlowGeroa") ,
                                  new Department("dep002",1,"El Marquez"),
                                  new Department("dep001",1,"Geovis") };
            
            _mockRepository.Setup(repo => repo.Get()).Returns(departments);

            var currentResponse = _departmentController.Get();

            var viewResult = Assert.IsType<OkObjectResult>(currentResponse);

            var model = Assert.IsAssignableFrom<IEnumerable<Department>>(viewResult.Value);
            Assert.Equal(3, model.Count());
            
        }

        [Fact]
        public void ShouldHaveHttpGetAttributeInGetDepatmentsMethod()
        {
            MethodBase method = typeof(DepartmentsController).GetMethod("Get");
            var mathodAttributes = method.GetCustomAttributes(typeof(HttpGetAttribute),false).FirstOrDefault();
 
            Assert.IsType<HttpGetAttribute>(mathodAttributes);
        }

        [Fact]
        public void ShouldReturn503WhenGetThrowException()
        {            
            const int statusCodeExpected = 503;
            
            _mockRepository.Setup(repo => repo.Get()).Throws(new Exception());
            var currentResponse = _departmentController.Get();

            var currentCode = Assert.IsType<StatusCodeResult>(currentResponse);
            Assert.Equal(statusCodeExpected, currentCode.StatusCode);
        }
        
        [Fact]
        public void ShouldReturn200With1DepartmentsWhenSetValidDepartmentNumberId()
        {
            var departmentNumber = "dep001";
            var department =  new Department("dep001",1,"FlowGeroa");           

            _mockRepository.Setup(repo => repo.GetById(departmentNumber)).Returns(department);

            var currentResponse = _departmentController.GetById(departmentNumber);
            var viewResult = Assert.IsType<OkObjectResult>(currentResponse);
            var model = Assert.IsAssignableFrom<Department>(viewResult.Value);
            var excpectedDepartment = department;

            Assert.Equal(excpectedDepartment.Number, model.Number);
            Assert.Equal(excpectedDepartment.Floor, model.Floor);
            Assert.Equal(excpectedDepartment.Owner, model.Owner);          
        }

        [Fact]
        public void ShouldReturn500WhenGetbyIDThrowException()
        {            
            const int statusCodeExpected = 503;
            const string departmentNumber = "dep001";

            _mockRepository.Setup(repo => repo.GetById(departmentNumber)).Throws(new Exception());
            var currentResponse = _departmentController.GetById(departmentNumber);

            var currentCode = Assert.IsType<StatusCodeResult>(currentResponse);
            Assert.Equal(statusCodeExpected, currentCode.StatusCode);
        
        }

        [Fact]
        public void ShouldReturn404With1DepartmentsWhenSetInvalidDepartmentNumberId()
        {
            var departmentNumber = "InvalidNumber";
            
            _mockRepository.Setup(repo => repo.GetById(departmentNumber)).Returns((Department)null);

            var currentResponse = _departmentController.GetById(departmentNumber);
            
            var viewResult = Assert.IsType<NotFoundObjectResult>(currentResponse); 
            var model = Assert.IsAssignableFrom<String>(viewResult.Value);
            Assert.Equal($"Value {departmentNumber} not found",model); 
        }

        [Fact]
        public void ShouldHaveHttpGetAttributeInGetDepatmentsById()
        {
            MethodBase method = typeof(DepartmentsController).GetMethod("GetById");
            var mathodAttributes = method.GetCustomAttributes(typeof(HttpGetAttribute),false).FirstOrDefault();
 
            Assert.IsType<HttpGetAttribute>(mathodAttributes);
        }
    }
}