using FarmAdvisorApi.Models;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace FarmAdvisor.DataAccess.AzureTableStorage.Services
{
    // building an interface for crud operation of WeatherForecast Table
    public interface IWeatherForecastStorage
    {

        Task<AzureDataModel> GetEntityAsync(string sensorId, string date);
        Task<AzureDataModel> UpsertEntityAsync(AzureDataModel entity);
        Task DeleteEntityAsync(string sensorId, string date);





        // Task<DataModel> GetEntityAsync(string sensorId, string lastForecastDate);
        //
        // // upsert includes both creating and updating
        // Task<DataModel> UpsertEntityAsync(DataModel entity);
        // Task DeleteEntityAsync(string SensorId, string LastForecastDate);
    }
}
