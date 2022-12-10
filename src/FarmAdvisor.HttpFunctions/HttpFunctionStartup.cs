using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using FarmAdvisor.Services.WeatherApi;


[assembly: FunctionsStartup(typeof(FarmAdvisor.HttpFunctions.HttpFunctionStartup))]

namespace FarmAdvisor.HttpFunctions
{
    public class HttpFunctionStartup : FunctionsStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<FetchingWeatherForecast>();

        }

        public override void Configure(IFunctionsHostBuilder builder) =>
            ConfigureServices(builder.Services);
    }
}
