using Xunit;

namespace MarkI.Department.Tests
{
    
    public class DepartmentTest
    {
        [Fact]
        public void ShouldCreateNewDepartment()
        {
            string currentNumberDepartment = "100A";
            var currentFloor = 1;
            string currentOwner = "Wilmer Kaviedes";

            var currentDeparment = new MarkI.Domain.Department(currentNumberDepartment,currentFloor,currentOwner);

            Assert.Equal(currentNumberDepartment, currentDeparment.Number);
            Assert.Equal(currentFloor, currentDeparment.Floor);
            Assert.Equal(currentOwner, currentDeparment.Owner);
        }

    
        
    }
}