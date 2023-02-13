using Azure.Data.Tables;
using Azure.Storage;
using FarmAdvisorApi.Models;
using Microsoft.Extensions.Configuration;


namespace FarmAdvisor.DataAccess.AzureTableStorage.Services
{
    public class WeatherForecastStorageImpl : IWeatherForecastStorage
    {
        
        private const string TableName = "WeatherForecastStorageService";
        private readonly IConfiguration _configuration;
        

        public WeatherForecastStorageImpl(IConfiguration configuration)
        {
            
            _configuration = configuration;
        }

        private async Task<TableClient> GetTableClient()
        {
            
            var serviceClient = new TableServiceClient("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;EndpointSuffix=core.windows.net");
            var tableclient = serviceClient.GetTableClient(TableName);
            await tableclient.CreateIfNotExistsAsync();

            return tableclient;
        }
        // How to call this function from outside
        // var res = await _storage.GetEntityAsync("001", "2023-01-01");
        // var res = await _storageService.GetEntityAsync("001", "2023-01-01");
        public async Task<AzureDataModel> GetEntityAsync(string sensorId, string date)
        {
            var tableClient = await GetTableClient();
            return await tableClient.GetEntityAsync<AzureDataModel>(sensorId, date);
        }

        // this is how you create and update an item in azure storage table
        // if you provide an existing Primary key ilt will update the value but if you provide a new one it will add it to the storage
        // CalculatedGddEntity entity = new CalculatedGddEntity();
        // entity.PartitionKey = "002";
        // entity.Date = "2023-01-04";
        // entity.RowKey = entity.Date;
        // entity.calculatedGdd = 135;
        // entity.calculatedTemperature = 125;
        
        // var res = await _storageService.UpsertEntityAsync(entity);
        public async Task<AzureDataModel> UpsertEntityAsync(AzureDataModel entity)
        {
            var tableClient = await GetTableClient();
            await tableClient.UpsertEntityAsync(entity);
            return entity;
        }

        // This is how you delete an item from azure table
        // await _storageService.DeleteEntityAsync("001", "2023-01-04");
        public async Task DeleteEntityAsync(string sensorId, string date)
        {
            var tableClient = await GetTableClient();

            await tableClient.DeleteEntityAsync(sensorId, date);
        }

    }
}
