using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FarmAdvisor.Services.WeatherApi;

namespace FarmAdvisor.HttpFunctions;

public static class TimeTriggeredFunction
{
    [FunctionName("TimeTriggeredFunction")]
    public static async Task RunAsync([TimerTrigger("5-7 * * * * *")] TimerInfo myTimer, ILogger log)
    {
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}");
        /*
         * call the weather api function from here
         */
        // var res = await FetchingWeatherForecast.GetForecastData();
        // log.LogInformation(res);

    }
}