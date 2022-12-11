using FarmAdvisorApi.Models;

namespace StonePorch.Tests.Mocks
{
    public interface IAzuritTableStorage
    {

      
        Task<CalculatedGddEntity> UpsertEntityAsync(CalculatedGddEntity entity);
        Task<CalculatedGddEntity> DeleteEntityAsync(string SensorId, string CalculatedGdd);
        Task<CalculatedGddEntity> GetEntityAsync<CalculatedGddEntity>(string SensorId , string CalculatedGdd );
        Task<SensorDataStorageEntity> UpsertEntityAsync(SensorDataStorageEntity entity);
        Task<WeatherForecastEntity> UpsertEntityAsync(WeatherForecastEntity entity);
        
    }
}