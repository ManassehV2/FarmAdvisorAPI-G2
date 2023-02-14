
using FarmAdvisor.HttpFunctions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace FarmAdvisorApiIntegrationTest
{
    public class TestServerFixture : IDisposable
{
    public TestServer Server { get; }
    public HttpClient Client { get; }

    public TestServerFixture()
    {
        var builder = new WebApplicationFactory<HttpFunctionStartup>()
            .WithWebHostBuilder(configure =>
            {
                configure.UseStartup<TestStartup>();
            });

        Server = builder.Server;
        Client = builder.CreateClient();
    }

    public void Dispose()
    {
        Client.Dispose();
        Server.Dispose();
    }
}

}
