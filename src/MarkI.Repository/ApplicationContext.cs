using MarkI.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarkI.Repository
{
    public class ApplicationContext : DbContext 
    {
        private DbContextOptionsBuilder _contextBuilder;

        public ApplicationContext(DbContextOptionsBuilder options): base (options.Options) 
        {
            _contextBuilder = options;
         }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            if(_contextBuilder == null)
            optionsBuilder.UseNpgsql("Server=localhost;database=testMigrations ;User ID=slin;Password=example;Port=5431;Integrated Security=true;Pooling=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
 
            modelBuilder.Entity<Department>()
            .HasKey(d => new { d.Number});

            modelBuilder.Entity<Department>()
            .HasKey(d => new { d.Id});
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons {get; set;}
        
    }
}