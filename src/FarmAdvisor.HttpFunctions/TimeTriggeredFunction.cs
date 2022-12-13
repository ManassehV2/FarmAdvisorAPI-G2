using System;
using System.Threading.Tasks;
using FarmAdvisor.Models.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FarmAdvisor.Services.WeatherApi;

namespace FarmAdvisor.HttpFunctions;

public class TimeTriggeredFunction
{
    public readonly IWeatherRemoteRepository _weatherForecast;

    public TimeTriggeredFunction(IWeatherRemoteRepository weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }
    
    [FunctionName("TimeTriggeredFunction")]
    public async Task RunAsync([TimerTrigger("0 0 5 * * *")] TimerInfo myTimer, ILogger log)
    {
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}");
        /*
         * call the weather api function from here
         */
        WeatherForecastModel res = await _weatherForecast.GetForecastData(1.2, 2.3);
        log.LogInformation(res.Type);

    }
}