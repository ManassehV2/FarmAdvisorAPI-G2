using FarmAdvisor.Models.Models;

namespace FarmAdvisor.Services.WeatherApi
{

    public interface IFetchingWeatherForecast
    {
        Task<List<SensorWeatherData>> SensorWeatherForecast(List<Sensor> sensors);
    }
}