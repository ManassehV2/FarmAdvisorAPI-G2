using Azure.Data.Tables;
using FarmAdvisorApi.Models;
using Microsoft.Extensions.Configuration;


namespace FarmAdvisor.DataAccess.AzureTableStorage.Services

{
    public class CalculatedGddStorageService : ICalculatedGddService
    {
        private const string TableName = "CalculatedGddStorageService";
        private readonly IConfiguration _configuration;

        public CalculatedGddStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // implementing crud operation

        //reading
        public async Task<CalculatedGddEntity> GetEntityAsync(string SensorId, string CalculatedGdd)
        {
            var tableClient = await GetTableClient();
            return await tableClient.GetEntityAsync<CalculatedGddEntity>(SensorId, CalculatedGdd);
        }

        //Upsert includes an operation that inserts the given entity into a table if it does not exist and replaces the contents in case the entity already exists.
        public async Task<CalculatedGddEntity> UpsertEntityAsync(CalculatedGddEntity entity)
        {
            var tableClient = await GetTableClient();
            await tableClient.UpsertEntityAsync(entity);
            return entity;
        }

        //delete operation
        public async Task DeleteEntityAsync(string SensorId, string CalculatedGdd)
        {
            var tableClient = await GetTableClient();
            await tableClient.DeleteEntityAsync(SensorId, CalculatedGdd);
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
