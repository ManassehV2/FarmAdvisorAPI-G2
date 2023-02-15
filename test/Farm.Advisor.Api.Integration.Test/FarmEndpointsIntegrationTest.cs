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

namespace FarmAdvisor.IntegrationTest
{
    public sealed class TestFarmEndpoints
    {
        readonly FarmFunctions _farmFunctions;
        public TestFarmEndpoints()
        {
            var startup = new HttpFunctionStartup();
            var host = new HostBuilder()
                .ConfigureWebJobs(startup.Configure)
                .Build();

            _farmFunctions = new FarmFunctions(host.Services.GetRequiredService<FarmService>());
        }

        

        [Fact]
        public async Task GetFarms()
        {

            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.ContentType = "application/json";
            var jsonResult = await _farmFunctions.GetAllFarms(request);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);


            
        }
        // tes
        [Fact]
        public async Task CreateFarm()
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
            var jsonResult = await _farmFunctions.CreateFarm(request);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);   
        }  

         [Fact]
        public async Task GetFarmById()
        {
            var id = new Guid();
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.ContentType = "application/json";
            var jsonResult = await _farmFunctions.GetFarmByUserId(request, id);
            var result = (NotFoundObjectResult)jsonResult;
            Assert.Equal(404, (int)result.StatusCode);


            
        } 

    }
}