using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmAdvisor.DataAccess.MSSQL
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var  connectionString = "Data Source=LAPTOP-7S5M2IVT;Initial Catalog=FarmAdvisor1;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            services.AddDbContext<FarmAdvisorDbContext>(options =>
                options.UseSqlServer(connectionString!, b => b.MigrationsAssembly(typeof(FarmAdvisorDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddTransient<IFarmAdvisorDbContext>(provider => provider.GetService<FarmAdvisorDbContext>()!);
            services.AddTransient<IUnitOfWork, UnitOfWorkImpl>();
        
            return services;
        }
    }
}