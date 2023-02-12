
using FarmAdvisor.Business;
using Microsoft.Extensions.Hosting;





var host = new HostBuilder().
ConfigureServices(
    (hostContext, services) => services.AddBusinessDependencyConfig(hostContext.Configuration))
    .Build();

host.Run();