using MarkI.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarkI.Repository
{
    public class DepartmentsContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder.UseNpgsql("Server=localhost;database=test ;User ID=slin;Password=example;Port=5431;Integrated Security=true;Pooling=true;");
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
 
            modelBuilder.Entity<Department>()
            .HasKey(d => new { d.Number});
        }
        public DbSet<Department> Departments { get; set; }
        
    }
}