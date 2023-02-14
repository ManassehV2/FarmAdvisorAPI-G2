using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FarmAdvisor.Business;
// using FarmAdvisor.Business;
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


namespace FarmAdvisor.HttpFunctions.Functions
{
    public class FarmFieldFunctions
    {
        private readonly FarmFieldService _farmFieldService;
        private readonly IWeatherForecastStorage _storageService;
        public readonly IFetchingWeatherForecast _weatherForecast;
        private readonly ILogger<FarmFieldFunctions> _logger;

        public FarmFieldFunctions(ILogger<FarmFieldFunctions> logger, IWeatherForecastStorage storageService, IFetchingWeatherForecast weatherForecast,FarmFieldService farmFieldService)
        {
            _logger = logger;
            _storageService = storageService;
            _weatherForecast = weatherForecast;
            _farmFieldService = farmFieldService;
        }
        
        [FunctionName("Getfields")]
        [OpenApiOperation(operationId: "GetAllFarmFields", tags: new[] { "FarmFields" },Summary = "Gets all fields in a farm.",Description = "Gets all fields in a farm.",Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key",SecuritySchemeType.ApiKey,Name = "code",In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK,contentType: "application/json",bodyType: typeof(string),Description = "List of fields in a farm" )]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest,Summary = "Invalid ID supplied",Description = "Invalid ID supplied")]
        public async Task<IActionResult> GetFields(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/fm/fields")]
                HttpRequest req
        )
        {

            List<Sensor> sensors= new List<Sensor>();
            foreach(var i in Enumerable.Range(1,10))
            {
                var sensor = new Sensor(
                    Guid.NewGuid(),
                    String.Format("serial{0}", i.ToString()),
                   38 + i / 10,
                     8.5 + i / 10,
                     300 + i,
                    Guid.NewGuid(),
                     DateTime.Now,
                     DateTime.Now
                    
                );
                sensors.Add(sensor);
            }
            
            var res = await _weatherForecast.SensorWeatherForecast(sensors);
            foreach (var kvp in res)
            {
                foreach (var val in kvp.ForecastGDD)
                {
                    AzureDataModel entity = new AzureDataModel();
                    entity.PartitionKey = kvp.SensorId.ToString();
                    
                    entity.RowKey = val.Key;
                    entity.calculatedGdd = val.Value;
                    entity.calculatedTemperature = kvp.ForecastTemperature[val.Key];
                
                    var ressult = await _storageService.UpsertEntityAsync(entity);
                    Console.WriteLine(ressult.calculatedGdd);
                    Console.WriteLine(ressult.calculatedTemperature);
                }

            }

            return new OkObjectResult("ok");
        }
        
        
        [FunctionName("CreateFarmField")]
        [OpenApiOperation(operationId: "CreateFarmField", tags: new[] { "CreateFarmField" }, Summary = "CreateFarmField.", Description = "CreateFarmField.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<FarmFieldModel>), Description = "List of fields in a farm")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Created, Summary = "Unable to Create Farm Field", Description = "Unable to Create Farm Field")]
        public async Task<IActionResult> CreateFarmField(
             [HttpTrigger(AuthorizationLevel.Function, "post", Route = "farmFields")] HttpRequest req)
        {
            try{
                var farmField = new FarmFieldModel(null, req.Form["name"], decimal.Parse(req.Form["altitude"]), new Guid(req.Form["farmId"]));
                var result = await _farmFieldService.CreateFarmField(farmField);
                return new OkObjectResult(result);
            }catch(Exception ex){
                return new BadRequestObjectResult(ex.Message);
            }
        }
        //
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