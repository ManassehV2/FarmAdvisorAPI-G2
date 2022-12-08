
using FarmAdvisor.DataAccess.MSSQL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmAdvisor.Business
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddBusinessConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDataAccess(configuration);

            return services;
            
        }
    }
}