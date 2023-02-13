using System.Net;
using FluentAssertions;

namespace FarmAdvisorApiIntegrationTest
{
    public class UserEndpointesIntegrationTest
    {
        [Fact]
        public async Task GetUsersEndpoint()
        {
            using(var client = new ClientProvider()._client)
            {
                var response = await client.GetAsync("/api/users");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

        }
    }
}