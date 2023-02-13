
using FarmAdvisor.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
var host = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("local.settings.json", optional: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddBusinessDependencyConfig(hostContext.Configuration);
        
            })
            .Build();
host.Run();
