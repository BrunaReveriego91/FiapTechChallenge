using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace FiapTechChallenge.API.Tests.IntegrationTests
{
    public class TransacaoTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _httpClient;
        public TransacaoTests(WebApplicationFactory<Startup> fixture)
        {
            _httpClient = fixture.CreateClient();
        }

        [Theory]
        [InlineData("/Transacao")]
        public async Task ListarTransacoes(string url)
        {
            //Arrange & Act
            var response = await _httpClient.GetAsync(url);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
