using MarkI.Domain;
using MarkI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace MarkI.RepositoryTests
{
    public class RepositoryBaseTest
    {
        private DbContextOptionsBuilder<ApplicationContext> _options;

        public RepositoryBaseTest()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                                .UseInMemoryDatabase(databaseName: "Add_writes_to_database");
            
        }

        [Fact]
        public void ShouldCallContextSaveWhenICallSaveRepository()
        {
               
            var department = new Department("dep001", 1, "Giovanny Kaviedes");

            using (var context = new ApplicationContext(_options))
            {
                var repository = new RepositoryBase<Department>(context);
                repository.Add(department);
            }

            using (var context = new ApplicationContext(_options))
            {
                var repository = new RepositoryBase<Department>(context);
                
                var departmentExpected = repository.GetById("dep001");
                Assert.NotNull(departmentExpected);
                Assert.Equal("Giovanny Kaviedes", departmentExpected.Owner);
            } 

        }

        [Fact]
        public void ShouldReturn3DepatmentsWhenRequestThem()
        {
            var giovisDepartment = new Department("dep001", 1, "Giovanny Kaviedes");
            var damiDepartment = new Department("dep002", 1, "Dami Dami");
            var figueHole = new Department("dep003", 1, "Cojito Figuemora");

            using (var context = new ApplicationContext(_options))
            {
                var repository = new RepositoryBase<Department>(context);
                repository.Add(giovisDepartment);
                repository.Add(damiDepartment);
                repository.Add(figueHole);
            }

            
            using (var context = new ApplicationContext(_options))
            {
                var repository = new RepositoryBase<Department>(context);
                var currentDepartments=repository.Get();

                Assert.Equal(3,currentDepartments.Count);

            }


        }
    }
}