using Md.Bot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Md.Bot.Persistentce.Data
{
    public class TelegramDbContext : DbContext
    {
        public DbSet<TelegramUser> TelegramUsers { get; set; } = null!;

        public TelegramDbContext(DbContextOptions<TelegramDbContext> options) : base(options) { }
    }
}
