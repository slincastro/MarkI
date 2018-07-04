using System;
using MarkI.Departments;
using MarkI.Domain;
using MarkI.IRepository;
using MarkI.Repository.Stub;
using Moq;
using Xunit;


namespace MarkI.Departments.Tests
{
    public class DepartmentServiceTest
    {
        private Department _currentDepartment;
        private Mock<IDepartments> _mockRepository;

        public DepartmentServiceTest()
        {
            string currentNumberDepartment = "100A";
            var currentFloor = 1;
            string currentOwner = "Wilmer Kaviedes";

            var currentDepartment = new Department(currentNumberDepartment,currentFloor,currentOwner);
            
            _currentDepartment = currentDepartment; 

            _mockRepository = new Mock<IDepartments>();
        }

        [Fact]
        public void ShouldReturnTrueWhenSendValidDepartment()
        {
            SetupMockRepositoryWithTrue();

            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_currentDepartment);

            Assert.True(currentResponse);
        }

        [Fact]
        public void ShouldReturnFalseWhenCanNotSave()
        {
            SetupMockRepositoryWith(false);
            
            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_currentDepartment);

            Assert.False(currentResponse);
        }

        [Fact]
        public void ShouldCallRepositoryOneTimeWhenIAddNewDepartment()
        {
            SetupMockRepositoryWithTrue();
                        
            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_currentDepartment);

            _mockRepository.Verify(f=>f.Add(_currentDepartment),Times.Exactly(1));

        }

        [Fact]
        public void ShouldCallRepositoryWithSameDepartmentWhenIAddNewDepartment()
        {
            SetupMockRepositoryWithTrue();
                        
            var currentResponse = new DepartmentService(_mockRepository.Object).Save(_currentDepartment);

            _mockRepository.Verify(f=>f.Add(It.Is<Department>(d => d.Equals(_currentDepartment))));

        }
        [Fact]
        public void ShouldReturnFalseWhenThrowinvalidOperationException()
        {
            _mockRepository.Setup(repo => repo.Add(_currentDepartment)).Throws(new InvalidOperationException());

            var response = new DepartmentService(_mockRepository.Object).Save(_currentDepartment);

            Assert.False(response);
        }

        private void SetupMockRepositoryWithTrue()
        {
            SetupMockRepositoryWith(true);
        }

        private void SetupMockRepositoryWith(bool value)
        {
            _mockRepository.Setup(repo => repo.Add(_currentDepartment)).Returns(value);
        }
    }
}