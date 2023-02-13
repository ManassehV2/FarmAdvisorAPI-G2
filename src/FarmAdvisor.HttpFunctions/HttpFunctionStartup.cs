using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using FarmAdvisor.DataAccess.AzureTableStorage.Services;
using FarmAdvisor.Services.WeatherApi;
using Microsoft.EntityFrameworkCore;
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Implementations;

[assembly: FunctionsStartup(typeof(FarmAdvisor.HttpFunctions.HttpFunctionStartup))]

namespace FarmAdvisor.HttpFunctions
{
    public class HttpFunctionStartup : FunctionsStartup
    {
       
        public  void ConfigureServices(IServiceCollection services)
        {
            // var ConfigBuilder = new ConfigurationBuilder();
            // ConfigBuilder.AddJsonFile("local.settings.json", optional: false);
            // ConfigBuilder.AddEnvironmentVariables();
            // var config = ConfigBuilder.Build();
            // var  connectionString = config.GetConnectionString("DefaultConnection");
           
            // services.AddDbContext<DataAccess.MSSQL.FarmAdvisorDbContext>(options =>
            //     options.UseSqlServer(connectionString!, b => b.MigrationsAssembly(typeof(DataAccess.MSSQL.FarmAdvisorDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            // services.AddTransient<IUnitOfWork, UnitOfWorkImpl>();
            services.AddHttpClient<IWeatherRemoteRepository>();
            services.AddScoped<IWeatherRemoteRepository, WeatherRemoteRepositoryImpl>();
            services.AddSingleton<IWeatherForecastStorage, WeatherForecastStorageImpl>();
            services.AddScoped<IFetchingWeatherForecast, FetchingWeatherForecastImpl>();

        }

        public override void Configure(IFunctionsHostBuilder builder) =>
            ConfigureServices(builder.Services);
    }
}
