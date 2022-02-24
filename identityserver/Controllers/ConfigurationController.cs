using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using Synapses.CRM.IdentityServer.Repositories;
using System.Threading.Tasks;

namespace Synapses.CRM.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConfigurationRepository _configurationRepository; 

        public ConfigurationController(ConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        [HttpPost("/client")]
        public async Task<Client> CreateClient(Client client)
        {
            return await _configurationRepository.CreateClient(client);
        }
        [HttpPost("/apiScope")]
        public async Task<ApiScope> CreateApiScope(ApiScope apiScope)
        {
            return await _configurationRepository.CreateApiScope(apiScope);
        }
        [HttpPost("/identityResource")]
        public async Task<IdentityResource> CreateIdentityResource(IdentityResource identityResource)
        {
            return await _configurationRepository.CreateIdentityResource(identityResource);
        }
        [HttpDelete("/client")]
        public void DeleteClient(Client client)
        {
            _configurationRepository.DeleteClient(client);
        }
        [HttpDelete("/apiScope")]
        public void DeleteApiScope(ApiScope apiScope)
        {
            _configurationRepository.DeleteApiScope(apiScope);
        }
        [HttpDelete("/identityResource")]
        public void DeleteIdentityResource(IdentityResource identityResource)
        {
            _configurationRepository.DeleteIdentityResource(identityResource);
        }
    }
}
