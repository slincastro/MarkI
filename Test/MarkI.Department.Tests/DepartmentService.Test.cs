using MarkI.Repository.Stub;
using Xunit;

namespace MarkI.Department.Tests
{
    public class DepartmentServiceTest
    {
        [Fact]
        public void ShouldReturnTrueWhenSendValidDepartment()
        {
            string currentNumberDepartment = "100A";
            var currentFloor = 1;
            string currentOwner = "Wilmer Kaviedes";

            var currentDepartment = new MarkI.Domain.Department(currentNumberDepartment,currentFloor,currentOwner);
            
            var currentResponse = new DepartmentService(new DeparmentsRepositoryTestOk()).Save(currentDepartment);

            Assert.True(currentResponse);

        }

        [Fact]
        public void ShouldReturnFalseWhenCanNotSave()
        {
            string currentNumberDepartment = "100A";
            var currentFloor = 1;
            string currentOwner = "Wilmer Kaviedes";

            var currentDepartment = new MarkI.Domain.Department(currentNumberDepartment,currentFloor,currentOwner);
            
            var currentResponse = new DepartmentService(new DeparmentRepositoryTestFalse()).Save(currentDepartment);

            Assert.False(currentResponse);

        }

        
    }
}