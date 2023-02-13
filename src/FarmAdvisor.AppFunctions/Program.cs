
using FarmAdvisor.Business;
using Microsoft.Extensions.Hosting;


var host = new HostBuilder().
    ConfigureServices(
    
    (hostContext, services) => services.AddBusinessDependencyConfig(config))
    .Build();
    

host.Run();
