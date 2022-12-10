using FarmAdvisor.Models.Models;

namespace FarmAdvisor.Services.WeatherApi
{
    public interface IWeatherRemoteRepository
    {
        Task<WeatherForecastModel> GetForecastData(double latitude, double longitude);
    }
}