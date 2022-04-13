using Md.Bot.Domain.Entities;
using Md.Bot.Persistentce.Data;
using Synapsess.Infrastructure.Interfaces;
using Synapsess.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Md.Bot.Persistentce
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddSingleton<IRepository<TelegramUser, long>, 
                RepositoryEF<TelegramUser, long, TelegramDbContext>>();
            
            services.AddTelegramDbContext(configuration);

            return services;
        }

        private static IServiceCollection AddTelegramDbContext(this IServiceCollection
            services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TelegramDbConnection");
            services.AddDbContext<TelegramDbContext>(options =>
                options.UseSqlite(connectionString), ServiceLifetime.Singleton);
            return services;
        }
    }
}
