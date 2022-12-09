using Azure.Data.Tables;
using FarmAdvisorApi.Models;
using Microsoft.Extensions.Configuration;


namespace FarmAdvisor.DataAccess.AzureTableStorage.Services

{
    public class SensorDataStorage : ISensorDataStorage
    {
        private const string TableName = "SensorDataStorage";
        private readonly IConfiguration _configuration;

        public SensorDataStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // implementing crud operation

        //reading
        public async Task<SensorEntity> GetEntityAsync(string category, string id)
        {
            var tableClient = await GetTableClient();
            return await tableClient.GetEntityAsync<SensorEntity>(category, id);
        }

        //Upsert includes an operation that inserts the given entity into a table if it does not exist and replaces the contents in case the entity already exists.
        public async Task<SensorEntity> UpsertEntityAsync(SensorEntity entity)
        {
            var tableClient = await GetTableClient();
            await tableClient.UpsertEntityAsync(entity);
            return entity;
        }

        //delete operation
        public async Task DeleteEntityAsync(string category, string id)
        {
            var tableClient = await GetTableClient();
            await tableClient.DeleteEntityAsync(category, id);
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
