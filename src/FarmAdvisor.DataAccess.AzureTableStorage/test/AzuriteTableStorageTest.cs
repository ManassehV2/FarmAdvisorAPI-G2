// using Xunit;


// using FarmAdvisor.DataAccess.AzureTableStorage.services;


// namespace FarmAdvisor.Function.Test.DataAccess.AzureTableStorage
// {
//     public class AzureTableStorageTest
//     {
//         public AzureTableStorageTest(string tableName)
//         {
//             TableName = tableName;
//         }

//         public string TableName { get; }

//         [Fact]
//         public async Task TestConnection()
//         {
//             string tableName = "Weather ";
//             var storage = new AzureTableStorageTest(tableName);
//             try
//             {
//                 await storage.DeleteEntityAsync<Weather>("del", "del");
//                 Assert.True(false);
//             }
//             catch
//             {
//                 Assert.True(true);
//             }
//         }

//         private Task DeleteEntityAsync<T>(string v1, string v2)
//         {
//             throw new NotImplementedException();
//         }

//         [Fact]
//         public async Task UpsertAndGetEntityTest()
//         {
//             string tableName = "Weather";
//             var storage = new TableStorageService(tableName);
//             var weather = new Weather();
//             weather.PartitionKey = "10";
//             weather.RowKey = "01";


//             var result =  await storage.UpsertEntityAsync<Weather>(weather);

//             var added = await storage.GetEntityAsync<Weather>(weather.PartitionKey, weather.RowKey);
//             Assert.Equal(result.Temprature, added.Temprature);
//             Assert.Equal(result.PartitionKey, added.PartitionKey);
//             Assert.Equal(result.RowKey, added.RowKey);


           
            
//         }

//         [Fact]
//         public async Task DeleteEntityTest()
//         {
//             string tableName = "Weather";
//             var storage = new TableStorageService(tableName);
//             var weather = new Weather();
//             weather.Temprature = 20;
//             weather.PartitionKey = "10";
//             weather.RowKey = "01";

//             await storage.UpsertEntityAsync<Weather>(weather);
//             await storage.DeleteEntityAsync<Weather>(weather.PartitionKey, weather.RowKey);

//             await Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await storage.GetEntityAsync<Weather>(weather.PartitionKey, weather.RowKey));

//             // Assert.Null(removed);
//         }
//     }

//     internal class Weather
//     {
//         internal string PartitionKey;

//         public Weather()
//         {
//         }

//         public string RowKey { get; internal set; }
//         public int Temprature { get; internal set; }
//     }
// }