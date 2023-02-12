using FarmAdvisor.DataAccess.MSSQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmAdvisor.Business
{
    public static class BDependencyInjectionConfig
    {
        public static IServiceCollection AddBusinessDependencyConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccess(configuration);
            services.AddScoped<FarmService, FarmService>();
            services.AddScoped<UserService, UserService>();
            services.AddScoped<FarmFieldService>();
            return services;
            
        }
    }
}