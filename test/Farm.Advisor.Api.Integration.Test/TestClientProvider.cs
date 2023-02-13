
using FarmAdvisor.HttpFunctions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace FarmAdvisorApiIntegrationTest
{
    public class ClientProvider: IDisposable
    {
        private TestServer _server;
        public HttpClient _client { get; private set;}
        public ClientProvider()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<HttpFunctionStartup>());
            _client = server.CreateClient();
        }

        public void Dispose()
        {
            _client?.Dispose();
            _server?.Dispose();
        }


    
    }
}
