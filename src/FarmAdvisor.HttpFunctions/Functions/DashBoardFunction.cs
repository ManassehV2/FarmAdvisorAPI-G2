using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FarmAdvisor.Business;
using FarmAdvisor.DataAccess.AzureTableStorage.Services;
// using FarmAdvisor.DataAccess.MSSQL.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FarmAdvisor.Models.Models;
using FarmAdvisor.Services.WeatherApi;
using FarmAdvisorApi.Models;

namespace FarmAdvisor.HttpFunctions.Functions;

public class DashBoardFunction
{
    private readonly DashboardService _dashboardService;
    private readonly IWeatherForecastStorage _storageService;
    public readonly IFetchingWeatherForecast _weatherForecast;
    private readonly ILogger<FarmFieldFunctions> _logger;

    public DashBoardFunction(ILogger<FarmFieldFunctions> logger, IWeatherForecastStorage storageService, IFetchingWeatherForecast weatherForecast,DashboardService dashboardService)
    {
        _logger = logger;
        _storageService = storageService;
        _weatherForecast = weatherForecast;
        _dashboardService = dashboardService;
    }
    
    [FunctionName("GetDashboardInformation")]
    [OpenApiOperation(operationId: "GetAllFarmFields", tags: new[] { "FarmFields" }, Summary = "Gets all information for the dashboard", Description = "Gets all information of a field.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<BoardInfoModel>), Description = "Fetch all information")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
    public async Task<IActionResult> GetDashboardInformation(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "farms/dashboard/{farmId}")] HttpRequest req, Guid farmId)
    {
        try{
            var result = await _dashboardService.GetDashboardInfo(farmId);
            return new OkObjectResult(result);
        }catch(Exception ex){
            return new BadRequestObjectResult(ex.Message);
        }
    }
    
    // [FunctionName("GetDashboardStatistics")]
    // [OpenApiOperation(operationId: "GetStatistics", tags: new[] { "FarmFields" }, Summary = "Gets all information for the dashboard statistics", Description = "Gets all information of a field.", Visibility = OpenApiVisibilityType.Important)]
    // [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
    // [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Dictionary<string, double>), Description = "Fetch all information")]
    // [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
    // public async Task<IActionResult> GetDashboardStatistics(
    //     [HttpTrigger(AuthorizationLevel.Function, "get", Route = "farms/dashboard/stat/{fieldId}")] HttpRequest req, Guid fieldId)
    // {
    //     try{
    //         var result = await _dashboardService.GetDashboardStatistics(fieldId, req.Form["startDate"], req.Form["endDate"]);
    //         return new OkObjectResult(result);
    //     }catch(Exception ex){
    //         return new BadRequestObjectResult(ex.Message);
    //     }
    // }
    [FunctionName("GetDashboardStatistics")]
    [OpenApiOperation(operationId: "GetStatistics", tags: new[] { "FarmFields" }, Summary = "Gets all information for the dashboard statistics", Description = "Gets all information of a field.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Dictionary<string, double>), Description = "Fetch all information")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
    public async Task<IActionResult> GetDashboardStatistics(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "farms/dashboard/stat/{fieldId}")] HttpRequest req, Guid fieldId)
    {
        try
        {
            string startDate = req.Query["startDate"];
            string endDate = req.Query["endDate"];
            var result = await _dashboardService.GetDashboardStatistics(fieldId, startDate, endDate);
            return new JsonResult(result);
        }
        catch(Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

}