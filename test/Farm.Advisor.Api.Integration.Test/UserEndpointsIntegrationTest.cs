using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FarmAdvisorApiIntegrationTest
{
    [Collection("TestServerCollection")]
    public class FunctionIntegrationTest
    {
        private HttpClient _client;
        private readonly TestServerFixture _fixture;

        public FunctionIntegrationTest(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task TestFunction()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/users");
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Add more assertions as needed
        }
    }
}
