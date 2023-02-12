using Azure;
using Azure.Data.Tables;
using System;

namespace FarmAdvisorApi.Models
{
    public class AzureDataModel : ITableEntity
    {
        public string SensorId { get; set; }
        public String Date { get; set; }
        public double calculatedGdd { get; set; }
        public double calculatedTemperature { get; set; }
        
        // partitionkey and rowkey are valuabel for azurite table storage
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
       
        public ETag ETag { get; set; }
    }
}
