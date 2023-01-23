using Azure.Data.Tables;
using FarmAdvisorApi.Models;
using Microsoft.Extensions.Configuration;


namespace FarmAdvisor.DataAccess.AzureTableStorage.Services

{
    public class WeatherForecastStorage : IWeatherForecastStorage
    {
        private const string TableName = "WeatherForecastStorageService";
        private readonly IConfiguration _configuration;

        public WeatherForecastStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // implementing crud operation

        //reading
        public async Task<WeatherForecastEntity> GetEntityAsync(string SensorId, string LastForecastDate)
        {
            var tableClient = await GetTableClient();
            return await tableClient.GetEntityAsync<WeatherForecastEntity>(SensorId, LastForecastDate);
        }

        //Upsert includes an operation that inserts the given entity into a table if it does not exist and replaces the contents in case the entity already exists.
        public async Task<WeatherForecastEntity> UpsertEntityAsync(WeatherForecastEntity entity)
        {
            var tableClient = await GetTableClient();
            await tableClient.UpsertEntityAsync(entity);
            return entity;
        }

        //delete operation
        public async Task DeleteEntityAsync(string SensorId, string LastForecastDate)
        {
            var tableClient = await GetTableClient();
            await tableClient.DeleteEntityAsync(SensorId, LastForecastDate);
        }

        private async Task<TableClient> GetTableClient()
        {
            var serviceClient = new TableServiceClient(_configuration["StorageConnectionString"]);

            var tableClient = serviceClient.GetTableClient(TableName);
            await tableClient.CreateIfNotExistsAsync();
            return tableClient;
        }
    }
}
