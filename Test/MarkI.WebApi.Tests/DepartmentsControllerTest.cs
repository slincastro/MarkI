using MarkI.Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MarkI.WebApi.Tests
{
    public class DepartmentsControllerTest
    {
        private DepartmentsController _departmentController;

        public DepartmentsControllerTest()
        {
            _departmentController = new DepartmentsController();
        }

        [Fact]
        public void ShouldReturn200WhenSendValidDepertment()
        {
            var department = new Department("dep001",1,"Wilmer Huge Calero");
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
    }
}