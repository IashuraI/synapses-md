using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Synapses.CRM.IdentityServer.Models;
using System;

namespace Synapses.CRM.IdentityServer.Data
{
    public class IdentityContext : IdentityDbContext<User, Role, Guid>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) 
            : base(options)
        {
        }
    }
}
