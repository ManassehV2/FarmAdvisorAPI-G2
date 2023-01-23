using System;
using System.Threading.Tasks;
using FarmAdvisor.Models.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FarmAdvisor.Services.WeatherApi;
using System.Collections.Generic;

namespace FarmAdvisor.HttpFunctions;

public class TimeTriggeredFunction
{
    public readonly FetchingWeatherForecast _weatherForecast;

    public TimeTriggeredFunction(FetchingWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }
    
    [FunctionName("TimeTriggeredFunction")]
    public async Task RunAsync([TimerTrigger("0 0 5 * * *")] TimerInfo myTimer, ILogger log)
    {
        List<Sensor> sensors = new List<Sensor>();
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}");
        await _weatherForecast.SensorWeatherForecast(sensors);

    }
}