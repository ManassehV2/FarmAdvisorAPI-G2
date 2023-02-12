using System;
using System.Collections.Generic;
using System.Linq;
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
using FarmAdvisor.DataAccess.AzureTableStorage.Services;
using FarmAdvisor.Services.WeatherApi;
using FarmAdvisorApi.Models;

namespace FarmAdvisor.HttpFunctions.Functions
{
    public class FarmFieldFunctions
    {
        private readonly ILogger<FarmFieldFunctions> _logger;
        private readonly IWeatherForecastStorage _storageService;
        public readonly IFetchingWeatherForecast _weatherForecast;


        public FarmFieldFunctions(ILogger<FarmFieldFunctions> logger, IWeatherForecastStorage storageService, IFetchingWeatherForecast weatherForecast)
        {
            _logger = logger;
            _storageService = storageService;
            _weatherForecast = weatherForecast;
        }

        [FunctionName("GetAllFarmFields")]
        [OpenApiOperation(
            operationId: "GetAllFarmFields",
            tags: new[] { "FarmFields" },
            Summary = "Gets all fields in a farm.",
            Description = "Gets all fields in a farm.",
            Visibility = OpenApiVisibilityType.Important
        )]
        [OpenApiSecurity(
            "function_key",
            SecuritySchemeType.ApiKey,
            Name = "code",
            In = OpenApiSecurityLocationType.Header
        )]
        // [OpenApiParameter(
        //     name: "farmId",
        //     In = ParameterLocation.Query,
        //     Required = true,
        //     Type = typeof(string),
        //     Description = "The fields farm Id"
        // )]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "application/json",
            bodyType: typeof(List<FarmFieldModel>),
            Description = "List of fields in a farm"
        )]
        [OpenApiResponseWithoutBody(
            statusCode: HttpStatusCode.BadRequest,
            Summary = "Invalid ID supplied",
            Description = "Invalid ID supplied"
        )]
        public async Task<IActionResult> GetAllFarmFields(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/fields")]
                HttpRequest req
        )
        {
            _logger.LogInformation("Executing {method}", nameof(GetAllFarmFields));
            // var res = await _storageService.GetEntityAsync("001", "2023-01-01");
            // var res = await _storageService.GetEntityAsync("001", "2023-01-01");
            
            // this is how you create and update an item in azure storage table
            // AzureDataModel entity = new AzureDataModel();
            // entity.PartitionKey = "001";
            // // entity.Date = "2023-01-01";
            // entity.RowKey = "2023-01-01";
            // entity.calculatedGdd = 135;
            // entity.calculatedTemperature = 125;
            //
            // var res = await _storageService.UpsertEntityAsync(entity);
            
            // This is how you delete an item from azure table
            // await _storageService.DeleteEntityAsync("001", "2023-01-04");
            Console.WriteLine("_______________________response is__________");
            // Console.WriteLine(res.GetType());
            // Console.WriteLine(res.calculatedGdd);
            // Console.WriteLine(res.calculatedTemperature);
            // Console.WriteLine(res.PartitionKey);
            // Console.WriteLine(res.RowKey);
            
            List<Sensor> sensors= new List<Sensor>();
            foreach(var i in Enumerable.Range(1,10))
            {
                var sensor = new Sensor{
                    SensorId = Guid.NewGuid(),
                    SerialNo = String.Format("serial{0}", i.ToString()),
                    LastCommunication = DateTime.Now,
                    BatteryStatus = 1,
                    OptimalGDD = 300 + i,
                    CuttingDateCaclculated = DateTime.Now,
                    LastForecastDate = DateTime.Now,
                    Long = 38 + i / 10,
                    Lat = 8.5 + i / 10,
                    State = State.OK
                };
            
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

            var result = new FarmFieldModel();
            return new OkObjectResult(result);
        }
    }
}
