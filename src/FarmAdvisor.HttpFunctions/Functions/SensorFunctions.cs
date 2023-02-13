// using System.Collections.Generic;
// using System.Net;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Azure.WebJobs;
// using Microsoft.Azure.WebJobs.Extensions.Http;
// using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
// using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
// using Microsoft.Extensions.Logging;
// using Microsoft.OpenApi.Models;
// using FarmAdvisor.Models.Models;
// using FarmAdvisor.Business;
// using FarmAdvisor.DataAccess.MSSQL.Abstractions;
// using FarmAdvisor.DataAccess.MSSQL.Implementations;
// using System;
//
// namespace FarmAdvisor.HttpFunctions.Functions
// {
//     public class SensorFunctions
//     {
//         private SensorService _sensorService;
//
//         public SensorFunctions( )
//         {
//             _sensorService = new SensorService(new UnitOfWorkImpl());
//         }
//         
//         [FunctionName("GetSensorsByFieldId")]
//         [OpenApiOperation(operationId: "GetSensorsByFieldId", tags: new[] { "GetSensorsByFieldId" }, Summary = "GetSensorsByFieldId", Description = "GetSensorsByFieldId", Visibility = OpenApiVisibilityType.Important)]
//         [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
//         [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Sensor>), Description = "GetSensorsByFieldId")]
//         [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
//         public async Task<IActionResult> GetSensorsByFieldId(
//              [HttpTrigger(AuthorizationLevel.Function, "get", Route = "fields/sensors/{fieldId}")] HttpRequest req, Guid fieldId)
//         {
//                 try{
//                     var result = await _sensorService.GetSensorByFieldId(fieldId);
//                     return new OkObjectResult(result);
//                 }catch( Exception ex){
//                     return new BadRequestObjectResult(ex.Message);
//                 }
//                 
//
//         }
//
//         [FunctionName("CreateSensor")]
//         [OpenApiOperation(operationId: "CreateSensor", tags: new[] { "CreateSensor" }, Summary = "CreateSensor.", Description = "CreateSensor.", Visibility = OpenApiVisibilityType.Important)]
//         [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
//         [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Sensor), Description = "CreateSensor")]
//         [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Created, Summary = "Unable to Create sensor", Description = "sensor")]
//         public async Task<IActionResult> CreateSensor(
//              [HttpTrigger(AuthorizationLevel.Function, "post", Route = "sensors")] HttpRequest req)
//         {
//                 try{
//                     var sensor = new Sensor(null, req.Form["serialNo"], double.Parse(req.Form["longitude"]), double.Parse(req.Form["latitude"]), int.Parse(req.Form["defaultGDD"]), Guid.Parse(req.Form["fieldId"]), DateTime.Parse(req.Form["lastCuttingDate"]), DateTime.Parse(req.Form["lastCommunication"]));
//                     var newSensor = _sensorService.CreateSensor(sensor);
//                     return new OkObjectResult(newSensor);
//                 }   catch(Exception ex){
//                     return new BadRequestObjectResult(ex.Message);
//                 }
//         }
//
//         [FunctionName("GetSensorById")]
//         [OpenApiOperation(operationId: "SensorById", tags: new[] { "SensorById" }, Summary = "SensorById", Description = "SensorById", Visibility = OpenApiVisibilityType.Important)]
//         [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Header)]
//         [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Sensor), Description = "SensorById")]
//         [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid ID supplied", Description = "Invalid ID supplied")]
//         public async Task<IActionResult> GetSensorById(
//              [HttpTrigger(AuthorizationLevel.Function, "get", Route = "sensors/{id}")] HttpRequest req, Guid id)
//         {
//             try{
//                 var result = await _sensorService.GetSensorById(id);
//                 return new OkObjectResult(result);
//             }catch(Exception ex){
//                 return new BadRequestObjectResult(ex.Message);
//             }
//         }
//
//
//     }
// }