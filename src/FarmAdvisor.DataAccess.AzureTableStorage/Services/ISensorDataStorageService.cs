using FarmAdvisorApi.Models;
using System.Threading.Tasks;
namespace FarmAdvisor.DataAccess.AzureTableStorage.Services
{
    // building an interface for crud operation of SensorDataStorage Table  .. It uses last sent temprature and Id
    public interface ISensorDataStorageService
    {

        Task<SensorDataStorageEntity> GetEntityAsync(string SensorId, String LastForecastDate);

        // upsert includes both creating and updating
        Task<SensorDataStorageEntity> UpsertEntityAsync(SensorDataStorageEntity entity);
        Task DeleteEntityAsync(string SensorId, String LastForecastDate);
    }
}
