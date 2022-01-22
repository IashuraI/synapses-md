using Md.Persistentce.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Md.Persistentce.Data
{
    public class IdentityDbContext : IdentityDbContext<User, Role, Guid>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options): base(options) { }
    }
}
