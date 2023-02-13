using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using FarmAdvisor.Business;
using FarmAdvisor.DataAccess.AzureTableStorage.Services;
using FarmAdvisor.DataAccess.MSSQL;
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Implementations;
using FarmAdvisor.Services.WeatherApi;
using Microsoft.EntityFrameworkCore;
using System.IO;

// using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(FarmAdvisor.HttpFunctions.HttpFunctionStartup))]

namespace FarmAdvisor.HttpFunctions
{
    public class HttpFunctionStartup : FunctionsStartup
    {
       
        public  void ConfigureServices(IServiceCollection services)
        {
            

            // local.settings access config
            var path = Path.Combine(Directory.GetCurrentDirectory(), "local.settings.json");
            var ConfigBuilder = new ConfigurationBuilder();
            ConfigBuilder.AddJsonFile(path, optional: false);
            ConfigBuilder.AddEnvironmentVariables();
            var config = ConfigBuilder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection"); 
            
            // DataAccess dependencies
            services.AddDbContext<FarmAdvisorDbContext>(options =>
            options.UseSqlServer(connectionString!, 
                                b => b.MigrationsAssembly(typeof(FarmAdvisorDbContext).Assembly.FullName)), 
                                ServiceLifetime.Transient);
            services.AddScoped<IUnitOfWork, UnitOfWorkImpl>();

            // External Api dependencies
            services.AddScoped<IWeatherRemoteRepository, WeatherRemoteRepositoryImpl>();
            services.AddScoped<IFetchingWeatherForecast, FetchingWeatherForecastImpl>();

            // Azure table dependencies
            services.AddSingleton<IWeatherForecastStorage, WeatherForecastStorageImpl>();
            
            // Business dependenies
            services.AddScoped<FarmFieldService>();
            services.AddScoped<FarmService>();
            services.AddScoped<UserService>();
            services.AddScoped<SensorService>();

        }

        public override void Configure(IFunctionsHostBuilder builder) =>
            ConfigureServices(builder.Services);
    }
}
