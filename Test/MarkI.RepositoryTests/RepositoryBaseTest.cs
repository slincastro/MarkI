using System;
using MarkI.Domain;
using MarkI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace MarkI.RepositoryTests
{
    public class RepositoryBaseTest : IDisposable
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
            
            LoadDepartments();
            
            using (var context = new ApplicationContext(_options))
            {
                var repository = new RepositoryBase<Department>(context);
                var currentDepartments = repository.Get();

                Assert.Equal(3, currentDepartments.Count);

            }


        }

        [Fact]
        public void ShouldReturn0DepatmentsWhenRequestWithNoExistentId()
        {
            LoadDepartments();

            using (var context = new ApplicationContext(_options))
            {
                var repository = new RepositoryBase<Department>(context);
                var currentDepartment = repository.GetById("InvalidId");

                Assert.Null(currentDepartment);
            }
        }

        [Fact]
        public void ShouldReturnOneDepatmentsWhenRequestWithValidId()
        {
            LoadDepartments();
            var expectedDepartment = new Department("dep001", 1, "Giovanny Kaviedes");
            using (var context = new ApplicationContext(_options))
            {
                var repository = new RepositoryBase<Department>(context);
                var currentDepartment = repository.GetById("dep001");

                Assert.Equal(expectedDepartment.Number,currentDepartment.Number);
                Assert.Equal(expectedDepartment.Floor,currentDepartment.Floor);
                Assert.Equal(expectedDepartment.Owner,currentDepartment.Owner);
            }
        }

        private void LoadDepartments()
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
        }

        [Fact]
        public void TestConection()
        {

            var giovisDepartment = new Department("dep001", 1, "Giovanny Kaviedes");
             using (var context = new ApplicationContext())
            {
                var repository = new RepositoryBase<Department>(context);
                repository.Get();
               
            }
        }

        public void Dispose()
        {
            using (var context = new ApplicationContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}