using System;
using System.Collections.Generic;
using MarkI.Services;
using MarkI.Domain;
using MarkI.IRepository;
using MarkI.Repository.Stub;
using Moq;
using Xunit;


namespace MarkI.Departments.Tests
{
    public class DepartmentServiceTest
    {
        private Department _department;
        private Mock<IDepartments> _mockRepository;

        public DepartmentServiceTest()
        {
            string currentNumberDepartment = "100A";
            var currentFloor = 1;
            string currentOwner = "Wilmer Kaviedes";

            var currentDepartment = new Department(currentNumberDepartment,currentFloor,currentOwner);
            
            _department = currentDepartment; 

            _mockRepository = new Mock<IDepartments>();
        }

        [Fact]
        public void ShouldReturnTrueWhenSendValidDepartment()
        {
            SetupMockRepositoryWithTrue();

            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_department);

            Assert.True(currentResponse);
        }

        [Fact]
        public void ShouldReturnFalseWhenCanNotSave()
        {
            SetupMockRepositoryWith(false);
            
            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_department);

            Assert.False(currentResponse);
        }

        [Fact]
        public void ShouldCallRepositoryOneTimeWhenIAddNewDepartment()
        {
            SetupMockRepositoryWithTrue();
                        
            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_department);

            _mockRepository.Verify(f=>f.Add(_department),Times.Exactly(1));

        }

        [Fact]
        public void ShouldCallRepositoryWithSameDepartmentWhenIAddNewDepartment()
        {
            SetupMockRepositoryWithTrue();
                        
            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_department);

            _mockRepository.Verify(f=>f.Add(It.Is<Department>(d => d.Equals(_department))));

        }
        [Fact]
        public void ShouldReturnFalseWhenThrowinvalidOperationException()
        {
            _mockRepository.Setup(repo => repo.Add(_department)).Throws(new InvalidOperationException());

            var response = new DepartmentService(_mockRepository.Object).Save(_department);

            Assert.False(response);
        }

        [Fact]
        public void ShouldReturnListDepartmentsWhenICallGetDepartments()
        {
            var departments = new List<Department>{_department, new Department("dep001",1,"FlowGeroa") ,
                                  new Department("dep002",1,"El Marquez"),
                                  new Department("dep001",1,"Geovis") };
            _mockRepository.Setup(repo => repo.Get()).Returns(departments);

            var currentDepartmets = new DepartmentService(_mockRepository.Object).Get();

            Assert.True(currentDepartmets.Count > 0);
        
        }

        [Fact]
        public void ShouldReturn1DepartmentWhenICallGetDepartmentById()
        {

            const string numberDepartment = "dep001";
            var expectedDepartment = _department;
            
            _mockRepository.Setup(repo => repo.GetById(numberDepartment)).Returns(_department);

            var currentDepartment = new DepartmentService(_mockRepository.Object).GetById(numberDepartment);

            Assert.Equal(_department.Number,currentDepartment.Number);
            Assert.Equal(_department.Floor,currentDepartment.Floor);
            Assert.Equal(_department.Owner,currentDepartment.Owner);
        
        }

         [Fact]
        public void ShouldReturnNullDepartmentWhenICallGetDepartmentById()
        {
            const string numberDepartment = "InvalidNumberDepartment";
            var expectedDepartment = _department;
            
            _mockRepository.Setup(repo => repo.GetById(numberDepartment)).Returns((Department)null);

            var currentDepartmet = new DepartmentService(_mockRepository.Object).GetById(numberDepartment);

            Assert.Null(currentDepartmet);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionWhenGetDepartmentsByIdFails()
        {
            const string numberDepartment = "departmentNumber";
            _mockRepository.Setup(repo => repo.GetById(numberDepartment)).Throws(new InvalidOperationException());

            var exception = Assert.Throws<ArgumentException>(()=> new DepartmentService(_mockRepository.Object).GetById(numberDepartment));
            const string expectedMessage = "We are having problems, contact the administrator. ";
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void ShouldThrowArgumentExceptionWhenGetDepartmentsFails()
        {
            _mockRepository.Setup(repo => repo.Get()).Throws(new InvalidOperationException());

            var exception = Assert.Throws<ArgumentException>(()=> new DepartmentService(_mockRepository.Object).Get());
            const string expectedMessage = "We are having problems, contact the administrator. ";
            Assert.Equal(expectedMessage, exception.Message);
        }

        private void SetupMockRepositoryWithTrue()
        {
            SetupMockRepositoryWith(true);
        }

        private void SetupMockRepositoryWith(bool value)
        {
            _mockRepository.Setup(repo => repo.Add(_department)).Returns(value);
        }
    }
}