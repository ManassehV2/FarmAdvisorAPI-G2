using FarmAdvisorApi.Models;
using System.Threading.Tasks;
namespace FarmAdvisor.DataAccess.AzureTableStorage.Services
{
    // building an interface for crud operation of WeatherForecast Table
    public interface IWeatherForecastStorage
    {
        Task<WeatherForecastEntity> GetEntityAsync(string SensorId, string Temprature);
        
        // upsert includes both creating and updating
        Task<WeatherForecastEntity> UpsertEntityAsync(WeatherForecastEntity entity);
        Task DeleteEntityAsync(string SensorId, string Temprature);
    }
}
