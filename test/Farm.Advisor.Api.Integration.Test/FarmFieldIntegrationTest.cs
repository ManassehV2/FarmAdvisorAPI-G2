using System.Net;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;
using FarmAdvisor.HttpFunctions;
using FarmAdvisor.HttpFunctions.Functions;
using FarmAdvisor.Business;
using FarmAdvisor.Models.Models;
using Newtonsoft.Json;
using System.Text;
using FarmAdvisor.DataAccess.AzureTableStorage.Services;
using FarmAdvisor.Services.WeatherApi;

namespace FarmAdvisor.IntegrationTest
{
    public sealed class TestFarmFieldEndpoints
    {
        readonly FarmFieldFunctions _farmFunctions;
        public TestFarmFieldEndpoints()
        {
            var startup = new HttpFunctionStartup();
            var host = new HostBuilder()
                .ConfigureWebJobs(startup.Configure)
                .Build();

            _farmFunctions = new FarmFieldFunctions(
                host.Services.GetRequiredService<ILogger<FarmFieldFunctions>>(),
                host.Services.GetRequiredService<IWeatherForecastStorage>(),
                host.Services.GetRequiredService<IFetchingWeatherForecast>(),
                host.Services.GetRequiredService<FarmFieldService>());
        }

        

        [Fact]
        public async Task CreateFarmField()
        {

            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.ContentType = "application/json";
            var jsonResult = await _farmFunctions.CreateFarmField(request);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);


            
        }
        // tes
        [Fact]
        public async Task GetFarmField()
        {
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            var UserId = new Guid();
            var farm = new Farm(null, "Farm", 9, 30, UserId);
            request.Method = "POST";
            request.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(farm);

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            request.Body = stream;

            request.ContentLength = stream.Length;
            request.ContentType = "application/json";
            var jsonResult = await _farmFunctions.GetFields(request);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);   
        }  

         [Fact]
        public async Task GetFarmFieldById()
        {
            var id = new Guid();
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.ContentType = "application/json";
            var jsonResult = await _farmFunctions.GetFarmFieldsByFarmId(request, id);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);
            
        } 
    }
}