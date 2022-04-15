using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Md.Domain.Entities.Orders;
using Md.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Md.Domain.Entities.Identity;
using Md.Domain.Entities.Customers;
using Md.Domain.Entities.Delivery;
using Md.Domain.Entities.Location;
using Md.Domain.Entities.Meals;

namespace Md.Persistentce.Data
{
    public class MdDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderMeal> OrderMeals { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<DeliveryMan> DeliveryMen { get; set; } = null!;

        public DbSet<Address> Addresses { get; set; } = null!;

        public DbSet<Meal> Meals { get; set; } = null!;

        public DbSet<ProductRecord> ProductRecords { get; set; } = null!;

        public MdDbContext(DbContextOptions<MdDbContext> options) : base(options) { }
    }
}
