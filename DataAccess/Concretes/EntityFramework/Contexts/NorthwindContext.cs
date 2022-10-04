using System.Data.Entity;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
