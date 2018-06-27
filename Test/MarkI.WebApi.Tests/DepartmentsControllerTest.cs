using MarkI.Domain;
using MarkI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

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
            _mockRepository.Setup(repo => repo.Save(department)).Returns(true);

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

        public void ShouldCallDepartmentsServicesWhenISendValidObject()
        {
            var currentDepartment = new Department("dep001",1,"Wilmer Kaviedes");
            _mockRepository.Setup(repo => repo.Save(currentDepartment)).Returns(true);
            var currentResponse = _departmentController.Save(currentDepartment);

            _mockRepository.Verify(f =>  f.Save(currentDepartment));

        }
    }
}