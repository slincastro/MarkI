using MarkI.Domain;
using MarkI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace MarkI.RepositoryTests
{
    public class RepositoryBaseTest
    {
        [Fact]
        public void ShouldCallContextSaveWhenICallSaveRepository()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                                .UseInMemoryDatabase(databaseName: "Add_writes_to_database");
           
            
            var department = new Department("dep001", 1, "Giovanny Kaviedes");

            using (var context = new ApplicationContext(options))
            {
                var repository = new RepositoryBase<Department>(context);
                repository.Add(department);
            }

            
            using (var context = new ApplicationContext(options))
            {
                var repository = new RepositoryBase<Department>(context);
                
                Department departmentExpected = repository.GetById("dep001");
                Assert.NotNull(departmentExpected);
                Assert.Equal("Giovanny Kaviedes", departmentExpected.Owner);
            }
            

        }
    }
}