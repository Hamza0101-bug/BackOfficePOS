using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{

    public class DataContext : DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand>  Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Branch> Branchs  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
      
    }
}
