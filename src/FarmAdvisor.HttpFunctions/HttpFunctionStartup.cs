using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using FarmAdvisor.DataAccess.AzureTableStorage.Services;
using FarmAdvisor.Services.WeatherApi;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(FarmAdvisor.HttpFunctions.HttpFunctionStartup))]

namespace FarmAdvisor.HttpFunctions
{
    public class HttpFunctionStartup : FunctionsStartup
    {
       
        public  void ConfigureServices(IServiceCollection services)
        {
            var ConfigBuilder = new ConfigurationBuilder();
            ConfigBuilder.AddJsonFile("local.settings.json", optional: false);
            ConfigBuilder.AddEnvironmentVariables();
            var config = ConfigBuilder.Build();
            



            var  connectionString = "Data Source=LAPTOP-7S5M2IVT;Initial Catalog=FarmAdvisorDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
            services.AddDbContext<DataAccess.MSSQL.FarmAdvisorDbContext>(options =>
                options.UseSqlServer(connectionString!, b => b.MigrationsAssembly(typeof(DataAccess.MSSQL.FarmAdvisorDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddTransient<DataAccess.MSSQL.Abstractions.IUnitOfWork, DataAccess.MSSQL.Implementations.UnitOfWorkImpl>();
            services.AddScoped<IWeatherRemoteRepository, WeatherRemoteRepositoryImpl>();
            services.AddSingleton<IWeatherForecastStorage, WeatherForecastStorageImpl>();
            services.AddScoped<IFetchingWeatherForecast, FetchingWeatherForecastImpl>();

        }

        public override void Configure(IFunctionsHostBuilder builder) =>
            ConfigureServices(builder.Services);
    }
}
