using Md.Domain.Entities.Order;
using Md.Domain.Entities.Product;
using Md.Infrastructure.Interfaces;
using Md.Infrastructure.Repositories;
using Md.Persistentce.Data;
using Md.Persistentce.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Md.Persistentce
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddSingleton<IRepository<Order, Guid>, RepositoryEF<Order, Guid, MdDbContext>>();
            services.AddSingleton<IRepository<Product, Guid>, RepositoryEF<Product, Guid, MdDbContext>>();
            
            services.AddMdDbContext(configuration);
            services.AddIdentityDbContext(configuration);

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddMdDbContext(this IServiceCollection
            services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MdDbConnection");
            services.AddDbContext<MdDbContext>(options =>
                options.UseNpgsql(connectionString), ServiceLifetime.Singleton);
            return services;
        }

        private static IServiceCollection AddIdentityDbContext(this IServiceCollection
            services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("IdentityDbConnection");
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(connectionString), ServiceLifetime.Singleton);
            return services;
        }
    }
}
