using FarmAdvisor.DataAccess.MSSQL;
using FarmAdvisor.HttpFunctions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Xunit;

namespace FarmAdvisorApiIntegrationTest
{
    public class TestStartup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<TestServerFixture>();
    }
}

}
