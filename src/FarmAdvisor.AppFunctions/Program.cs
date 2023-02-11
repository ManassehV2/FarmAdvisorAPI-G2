using FarmAdvisor.AppFunctions;
using FarmAdvisor.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;





var host = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("local.settings.json", optional: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddBusinessDependencyConfig(hostContext.Configuration);
                /*
                services.AddScoped<CreateFarmField, CreateFarmField>();
                services.AddScoped<CreateFarm, CreateFarm>();
                services.AddScoped<CreateUser, CreateUser>();

                services.AddScoped<GetFarmFieldById, GetFarmFieldById>();
                services.AddScoped<GetUserById, GetUserById>();
                services.AddScoped<GetFieldsInFarm, GetFieldsInFarm>();
                services.AddScoped<GetFarm, GetFarm>();

                services.AddScoped<DeleteFarm, DeleteFarm>();
                services.AddScoped<DeleteUser, DeleteUser>();*/
            })
            .Build();


host.Run();