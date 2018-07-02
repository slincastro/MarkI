using MarkI.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarkI.Repository
{
    public class DepartmentsContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseNpgsql("Server=localhost;database=postgres;User ID=postgres;Password=mysecretpassword;Port=5432;Integrated Security=true;Pooling=true;");
            //optionsBuilder.UsePostgreSql(@"host=server;database=test;user id=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
 
            modelBuilder.Entity<Department>()
            .HasKey(d => new { d.Number});
        }
        public DbSet<Department> Departments { get; set; }
        
    }
}