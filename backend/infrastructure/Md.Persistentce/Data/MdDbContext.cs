using Md.Domain.Entities.Order;
using Md.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Md.Persistentce.Data
{
    public class MdDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

        public MdDbContext(DbContextOptions<MdDbContext> options) : base(options) { }
    }
}
