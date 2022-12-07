
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmAdvisor.DataAccess.MSSQL
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FarmAdvisorDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(FarmAdvisorDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddTransient<IFarmAdvisorDbContext>(provider => provider.GetService<FarmAdvisorDbContext>()!);

            return services;
        }
    }
}