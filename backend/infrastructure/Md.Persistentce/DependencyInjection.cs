using Md.Domain.Entities.Orders;
using Md.Domain.Entities.Products;
using Md.Domain.Entities.Identity;
using Synapsess.Infrastructure.Interfaces;
using Synapsess.Infrastructure.Repositories;
using Md.Persistentce.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Md.Domain.Entities.Meals;
using Md.Domain.Entities.Customers;

namespace Md.Persistentce
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<Order, Guid>, RepositoryEF<Order, Guid, MdDbContext>>();
            services.AddScoped<IRepository<Meal, Guid>, RepositoryEF<Meal, Guid, MdDbContext>>();
            services.AddScoped<IRepository<Product, Guid>, RepositoryEF<Product, Guid, MdDbContext>>();
            services.AddScoped<IRepository<Customer, Guid>, RepositoryEF<Customer, Guid, MdDbContext>>();

            services.AddMdDbContext(configuration);

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<MdDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddMdDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MdDbConnection");
            services.AddDbContext<MdDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}
