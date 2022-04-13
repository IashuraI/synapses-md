using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Md.WebApi.Tests
{
    public class ImportantEndpointsTests
    {
        [Fact]
        public async Task SwaggerEndpointStatusCodeSuccess()
        {
            HttpClient httpClient = new();
            HttpResponseMessage httpResponseMessage = 
                await httpClient.GetAsync("https://localhost:7252/swagger/v1/swagger.json");

            Assert.True(httpResponseMessage.IsSuccessStatusCode);
        }

        [Fact]
        public async Task ODataEndpointStatusCodeSuccess()
        {
            HttpClient httpClient = new();
            HttpResponseMessage httpResponseMessage =
                await httpClient.GetAsync("https://localhost:7252/odata");

            Assert.True(httpResponseMessage.IsSuccessStatusCode);
        }

        [Fact]
        public async Task ODataMetadataEndpointStatusCodeSuccess()
        {
            HttpClient httpClient = new();
            HttpResponseMessage httpResponseMessage =
                await httpClient.GetAsync("https://localhost:7252/odata/$metadata");

            Assert.True(httpResponseMessage.IsSuccessStatusCode);
        }
    }
}