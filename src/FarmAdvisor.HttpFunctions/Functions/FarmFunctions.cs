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
using System;

namespace FarmAdvisor.HttpFunctions.Functions
{
    public class FarmFunctions
    {
        private readonly FarmService _farmService    ;

        public FarmFunctions( FarmService farmService)
        {
            _farmService = farmService;
        }
        
        [FunctionName("GetAllFarms")]
        [OpenApiOperation(operationId: "GetAllFarmFields", tags: new[] { "Farms" }, Summary = "Gets all farms", Description = "Gets all farms.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Farm>), Description = "List of farms")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NoContent, Summary = "No Farm Available", Description = "No Farm Available")]
        public async Task<IActionResult> GetAllFarms(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "farms")] HttpRequest req)
        {

                var result = await _farmService.GetAllFarms();
                return new OkObjectResult(result);

        }

        [FunctionName("CreateFarm")]
        [OpenApiOperation(operationId: "CreateFarm", tags: new[] { "Farms" }, Summary = "CreateFarm", Description = "GCreateFarm", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Farm), Description = "List of farms")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Failed to create farm", Description = "Failed to create farm")]
        public async Task<IActionResult> CreateFarm(
             [HttpTrigger(AuthorizationLevel.Function, "post", Route = "farms")] HttpRequest req)
        {
                var farm = new Farm(null, req.Form["name"], double.Parse(req.Form["latitude"]), double.Parse(req.Form["longitude"]), Guid.Parse(req.Form["userId"]));
                var result = await _farmService.AddFarm(farm);
                return new OkObjectResult(result);

        }

        [FunctionName("GetFarmByUserId")]
        [OpenApiOperation(operationId: "GetfarmByuserid", tags: new[] { "Farms" }, Summary = "Gets farm with user id", Description = "Gets all farms.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Farm>), Description = "List of farms")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NoContent, Summary = "No Farm Available", Description = "No Farm Available")]
        public async Task<IActionResult> GetFarmByUserId(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/farm/{userId}")] HttpRequest req, Guid userId)
        {
            try{
                var result = await _farmService.GetFarmByUserId(userId);
                return new OkObjectResult(result);
            }catch( Exception ex){
                return new NotFoundObjectResult(ex.Message);
            }
               

        }

        

    }
}