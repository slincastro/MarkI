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

        public DepartmentServiceTest()
        {
            string currentNumberDepartment = "100A";
            var currentFloor = 1;
            string currentOwner = "Wilmer Kaviedes";

            var currentDepartment = new Department(currentNumberDepartment,currentFloor,currentOwner);
            
            _currentDepartment = currentDepartment; 
        }

        [Fact]
        public void ShouldReturnTrueWhenSendValidDepartment()
        {
                 
            var currentResponse = new DepartmentService(new DeparmentsRepositoryTestOk()).Save(_currentDepartment);

            Assert.True(currentResponse);

        }

        [Fact]
        public void ShouldReturnFalseWhenCanNotSave()
        {
            
            var currentResponse = new DepartmentService(new DeparmentRepositoryTestFalse()).Save(_currentDepartment);

            Assert.False(currentResponse);

        }

         [Fact]
        public void ShouldCallRepositoryWhenIAddNewDepartment()
        {
            var mockRepository = new Mock<IDepartments>();
            mockRepository.Setup(repo => repo.Save(_currentDepartment)).Returns(true);
                        
            var currentResponse = new DepartmentService(mockRepository.Object).Save(_currentDepartment);

            mockRepository.Verify(f=>f.Save(_currentDepartment));

        }

        [Fact]
        public void ShouldCallRepositoryOneTimeWhenIAddNewDepartment()
        {
            var mockRepository = new Mock<IDepartments>();
            mockRepository.Setup(repo => repo.Save(_currentDepartment)).Returns(true);
                        
            var currentResponse = new DepartmentService(mockRepository.Object).Save(_currentDepartment);

            mockRepository.Verify(f=>f.Save(_currentDepartment),Times.Exactly(1));

        }

         [Fact]
        public void ShouldCallRepositoryWithSameDepartmentWhenIAddNewDepartment()
        {
            var mockRepository = new Mock<IDepartments>();
            mockRepository.Setup(repo => repo.Save(_currentDepartment)).Returns(true);
                        
            var currentResponse = new DepartmentService(mockRepository.Object).Save(_currentDepartment);

            mockRepository.Verify(f=>f.Save(It.Is<Department>(d => d.Equals(_currentDepartment))));

        }

        
    }
}