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
    public readonly IFetchingWeatherForecast _weatherForecast;

    public TimeTriggeredFunction(IFetchingWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }
    
    /* [FunctionName("TimeTriggeredFunction")]
    public async Task RunAsync([TimerTrigger("0 0 5 * * *")] TimerInfo myTimer)
    {
        List<Sensor> sensors = new List<Sensor>();
        await _weatherForecast.SensorWeatherForecast(sensors);

    } */
}