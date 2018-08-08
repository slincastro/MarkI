using MarkI.Domain;
using Xunit;

namespace MarkI.DomainTests
{
    public class PersonTest
    {
        [Fact]
        public void ShouldReturnTrueWhenValidAPerson()
        {
            var person = new Person { Name = "Giovis", LastName = "Kaviedes", DocumentId = "171984243213", Email = "giovissexy69@ups.edu.ec" };
            
            var result = person.IsValid();
            
            Assert.True(result);
        }

        [Theory]
        [InlineData(null,"testLastName","1232344323","giovissexy69@ups.edu.ec")]
        [InlineData("","testLastName","1232344323","giovissexy69@ups.edu.ec")]
        [InlineData("testName",null,"1232344323","giovissexy69@ups.edu.ec")]
        [InlineData("testName","","1232344323","giovissexy69@ups.edu.ec")]
        [InlineData("testName","testLastName",null,"giovissexy69@ups.edu.ec")]
        [InlineData("testName","TestLastName","","giovissexy69@ups.edu.ec")]
        [InlineData("testName","testLastName","testDocumentId",null)]
        [InlineData("testName","TestLastName","testDocumentId","")]
        [InlineData("","","","")]
        [InlineData(null,null,null,null)]
        public void ShouldReturnFalseWhenValidINvalidPerson(string name,string lastName,string documentId,string email)
        {
            var person = new Person { Name = name, LastName = lastName, DocumentId = documentId, Email = email};
            
            var valid = person.IsValid();

            Assert.False(valid);
        }
    }
}