using Azure;
using Azure.Data.Tables;
using System;

namespace FarmAdvisorApi.Models
{
    public class SensorDataStorageEntity : ITableEntity
    {
        public string? SensorId { get; set; }
        public DateTime? LastCommunication { get; set;}
        public double? Temprature { get; set; }
        public int? BatterStatus { get; set; }

        public DateTime? CuttingDateCalculated { get; set; }
        public String? LastForecastDate { get; set; }

        public string PartitionKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RowKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset? Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? FieldId { get; set; }
        public string? SerialNo { get; set; }
        public ETag ETag { get; set; }
    }
}
