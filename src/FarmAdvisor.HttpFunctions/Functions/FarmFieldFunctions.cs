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
    public class FarmFieldFunctions
    {
        private FarmFieldService _farmFieldService;

        public FarmFieldFunctions( )
        {
            _farmFieldService = new FarmFieldService(new UnitOfWorkImpl());
        }
        
        [FunctionName("GetAllFarmFields")]
        [OpenApiOperation(operationId: "GetAllFarmFields", tags: new[] { "FarmFields" }, Summary = "Gets all fields in a farm.", Description = "Gets all fields in a farm.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<FarmFieldModel>), Description = "List of fields in a farm")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        public async Task<IActionResult> GetAllFarmFields(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "farmFields")] HttpRequest req)
        {

                var result = await _farmFieldService.GetAllFarmFields();
                return new OkObjectResult(result);

        }

        [FunctionName("CreateFarmField")]
        [OpenApiOperation(operationId: "CreateFarmField", tags: new[] { "CreateFarmField" }, Summary = "CreateFarmField.", Description = "CreateFarmField.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<FarmFieldModel>), Description = "List of fields in a farm")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Created, Summary = "Unable to Create Farm Field", Description = "Unable to Create Farm Field")]
        public async Task<IActionResult> CreateFarmField(
             [HttpTrigger(AuthorizationLevel.Function, "post", Route = "farmFields")] HttpRequest req)
        {
                var farmField = new FarmFieldModel(null, req.Form["name"], decimal.Parse(req.Form["altitude"]), new Guid(req.Form["farmId"]));
                var result = await _farmFieldService.CreateFarmField(farmField);
                return new OkObjectResult(result);
        }

        [FunctionName("GetFarmFieldsByFarmId")]
        [OpenApiOperation(operationId: "GetAllFarmFields", tags: new[] { "FarmFields" }, Summary = "Gets all fields in a farm.", Description = "Gets all fields in a farm.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<FarmFieldModel>), Description = "List of fields in a farm")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
        public async Task<IActionResult> GetFarmFieldsByFarmId(
             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "farms/farmFields/{farmId}")] HttpRequest req, Guid farmId)
        {
            try{
                var result = await _farmFieldService.GetFarmFieldsByFarmId(farmId);
                return new OkObjectResult(result);
            }catch(Exception ex){
                return new BadRequestObjectResult(ex.Message);
            }
        }


    }
}