using System;
using MarkI.Domain;
using Xunit;

namespace MarkI.Departments.Tests
{
    
    public class DepartmentTest
    {
        private Department _currentDeparment;

        public DepartmentTest()
        {
            string currentNumberDepartment = "100A";
            var currentFloor = 1;
            string currentOwner = "Wilmer Kaviedes";

            _currentDeparment = new Department(currentNumberDepartment,currentFloor,currentOwner);
        }

        [Fact]
        public void ShouldCreateNewDepartment()
        {
            string expectedNumberDepartment = "100A";
            var expectedFloor = 1;
            string expectedOwner = "Wilmer Kaviedes";


            Assert.Equal(expectedNumberDepartment, _currentDeparment.Number);
            Assert.Equal(expectedFloor, _currentDeparment.Floor);
            Assert.Equal(expectedOwner, _currentDeparment.Owner);
        }

        [Theory]
        [InlineData(null, "WilmerKaviedes", "Number Department")]
        [InlineData("dep001", null, "Owner")]
        public void ShouldThrowArgumentExceptionWhenSendInvalidObject(string numberDepartment, string owner, string field)
        {
            string expectedMessage = $"the field {field} is invalid";
            const int floor = 1;

            Assert.Throws<ArgumentException>(() => new Department(numberDepartment, floor, owner))
                                            .WithMessage(expectedMessage);
            
        }

        [Fact]
        public void ShouldReturnTrueWhenDepartmentIsValid()
        {
            var isValid = _currentDeparment.IsValid();

            Assert.True(isValid);
        }

        [Theory]
        [InlineData("","Wilmer Kaviedes")]
        [InlineData("dep001","")]
        [InlineData("","")]
        public void ShouldReturnFalseWhenDepartmentIsInvalid(string numberDepartment,string owner)
        {
            const int floor = 1;
            var isValid = new Department(numberDepartment, floor, owner).IsValid();

            Assert.False(isValid);
        }



    
        
    }
}