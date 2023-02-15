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
    public sealed class TestUserFunctions
    {
        readonly UserFunctions  _userFunctions;
        public TestUserFunctions()
        {
            var startup = new HttpFunctionStartup();
            var host = new HostBuilder()
                .ConfigureWebJobs(startup.Configure)
                .Build();

            _userFunctions = new UserFunctions(host.Services.GetRequiredService<UserService>());
        }

        

        [Fact]
        public async Task GetUsers()
        {

            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "GET";
            request.ContentType = "application/json";
            var jsonResult = await _userFunctions.GetUsers(request);
            var result = (OkObjectResult)jsonResult;
            Assert.Equal(200, (int)result.StatusCode);


            
        }
        // tes
        [Fact]
        public async Task CreateUser()
        {
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;
            request.Method = "POST";
            request.ContentType = "application/json";
            var user = new User(null, "1010101011");
            var json = JsonConvert.SerializeObject(user);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            request.Body = stream;

            request.ContentLength = stream.Length;
            request.ContentType = "application/json";
            var jsonResult = await _userFunctions.CreateUser(request);
            var result = (BadRequestObjectResult)jsonResult;
            Assert.Equal(400, (int)result.StatusCode);   
        }    

    }
}