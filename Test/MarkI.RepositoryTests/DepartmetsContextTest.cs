using MarkI.Domain;
using MarkI.Repository;
using Moq;
using Xunit;

namespace MarkI.RepositoryTests
{
    public class DepartmetsContextTest 
    {
        [Fact]
        public void ShouldConfigureWithPsSqlWithConnectionString()
        {
            var mockContext = new Mock<DepartmentsContext>();

            using (var context = new DepartmentsContext())
            {
                context.Departments.Add(new Department("dep001",2,"Giovanny KAviedes"));
                context.SaveChanges();
            }
        }
    }
}