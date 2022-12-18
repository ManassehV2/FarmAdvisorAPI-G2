using Azure.Data.Tables;
using FarmAdvisorApi.Models;
using Microsoft.Extensions.Configuration;


namespace FarmAdvisor.DataAccess.AzureTableStorage.Services

{
    public class SensorDataStorageService : ISensorDataStorageService
    {
        private const string TableName = "SensorDataStorageService";
        private readonly IConfiguration _configuration;

        public SensorDataStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // implementing crud operation

        //reading
        public async Task<SensorDataStorageEntity> GetEntityAsync(string SensorId, string SensorData)
        {
            var tableClient = await GetTableClient();
            return await tableClient.GetEntityAsync<SensorDataStorageEntity>(SensorId, SensorData);
        }

        //Upsert includes an operation that inserts the given entity into a table if it does not exist and replaces the contents in case the entity already exists.
        public async Task<SensorDataStorageEntity> UpsertEntityAsync(SensorDataStorageEntity entity)
        {
            var tableClient = await GetTableClient();
            await tableClient.UpsertEntityAsync(entity);
            return entity;
        }

        //delete operation
        public async Task DeleteEntityAsync(string SensorId, string Temprature)
        {
            var tableClient = await GetTableClient();
            await tableClient.DeleteEntityAsync(SensorId, Temprature);
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
