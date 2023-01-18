
using FarmAdvisor.HttpFunctions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FarmAdvisor.Functions.Test.HttpFunctionsTest.Infrastructure
{
    public class HttpFunctionsTestStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<FarmFieldFunctionsTest>();
            HttpFunctionStartup.ConfigureServices(services);
        }
    }
}
