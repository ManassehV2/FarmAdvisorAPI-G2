using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FarmAdvisor.Models.Models;
using FarmAdvisor.Business;
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Implementations;
using System.IO;
using System;

namespace FarmAdvisor.HttpFunctions.Functions
{
    public class UserFunctions
    {
        private readonly UserService _userService;

        public UserFunctions( UserService userService)
        {
            _userService = userService;
        }
        
        [FunctionName("CreateUser")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "User" }, Summary = "create new user", Description = "create new user.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(User), Description = "create new user")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Unable to create user", Description = "Unable to create user")]
        public async Task<IActionResult> CreateUser(
             [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users")] HttpRequest req)
        {
                var user = new User(null , req.Form["phone"]);
                var result = await _userService.CreateUser(user);
                return new OkObjectResult(result);

        }

        [FunctionName("GetUsers")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "User" }, Summary = "create new user", Description = "create new user.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<User?>), Description = "create new user")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Unable to create user", Description = "Unable to create user")]
        public async Task<IActionResult> GetUsers(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequest req)
        {
                var result = await _userService.GetAllUsers();
                return new OkObjectResult(result);

        }

        [FunctionName("GetUserById")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "User" }, Summary = "get user by id", Description = "get user by id", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(User), Description = "get user by id")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid Id", Description = "No user is found with this id")]
        public async Task<IActionResult> GetUserById(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/{id}")] HttpRequest req, Guid id)
        {
            try{
                var result = await _userService.GetUser(id);
                return new OkObjectResult(result);
            }catch(Exception e){
                return  new BadRequestObjectResult(e.Message);
            }
        }


        

        

    }
}