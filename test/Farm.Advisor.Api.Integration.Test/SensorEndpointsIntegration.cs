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
    public sealed class TestSensorEndpoints
    {
        readonly SensorFunctions _sensorService;
        public TestSensorEndpoints()
        {
            var startup = new HttpFunctionStartup();
            var host = new HostBuilder()
                .ConfigureWebJobs(startup.Configure)
                .Build();

            _sensorService = new SensorFunctions(
                host.Services.GetRequiredService<SensorService>()

            );
        }

        

        [Fact]
        public async Task CreateSensor()
        {

            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.ContentType = "application/json";
            var jsonResult = await _sensorService.CreateSensor(request);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);


            
        }
        // tes
        [Fact]
        public async Task GetSensorById()
        {
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            var id = new Guid();
            request.ContentType = "application/json";
            var jsonResult = await _sensorService.GetSensorById(request,id );
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);   
        }  

         [Fact]
        public async Task GetSensorByFieldId()
        {
            var id = new Guid();
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.ContentType = "application/json";
            var jsonResult = await _sensorService.GetSensorsByFieldId(request, id);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);
            
        } 
    }
}