using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using System.Threading.Tasks;

namespace Synapses.CRM.IdentityServer.Repositories
{
    public class ConfigurationRepository
    {
        private readonly ConfigurationDbContext _configurationDbContext;

        public ConfigurationRepository(ConfigurationDbContext configurationDbContext)
        {
            _configurationDbContext = configurationDbContext;
        }
        public async Task<Client> CreateClient(Client client)
        {
            await _configurationDbContext.Clients.AddAsync(client.ToEntity());
            return client;
        }
        public async Task<IdentityResource> CreateIdentityResource(IdentityResource identityResource)
        {
            await _configurationDbContext.IdentityResources.AddAsync(identityResource.ToEntity());
            return identityResource;
        }
        public async Task<ApiScope> CreateApiScope(ApiScope apiScope)
        {
            await _configurationDbContext.ApiScopes.AddAsync(apiScope.ToEntity());
            return apiScope;
        }
        public void DeleteClient(Client client)
        {
            _configurationDbContext.Clients.Remove(client.ToEntity());
        }
        public void DeleteIdentityResource(IdentityResource identityResource)
        {
            _configurationDbContext.IdentityResources.Remove(identityResource.ToEntity());
        }
        public void DeleteApiScope(ApiScope apiScope)
        {
            _configurationDbContext.ApiScopes.Remove(apiScope.ToEntity());
        }
    }
}
