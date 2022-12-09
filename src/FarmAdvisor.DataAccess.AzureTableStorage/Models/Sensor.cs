using Azure;
using Azure.Data.Tables;
using System;

namespace FarmAdvisorApi.Models
{
    public class SensorEntity : ITableEntity
    {
        public Guid? SensorId { get; set; }
        public Guid? FieldId { get; set; }
        public string? SerialNo { get; set; }
        public DateTime? LastCommunication { get; set; }
        public int? BatterStatus { get; set; }
        public int? OptimalGDD { get; set; }
        public DateTime? CuttingDateCalculated { get; set; }
        public DateTime? LastForecastDate { get; set; }
        public double? Long { get; set; }
        public double? Lat { get; set; }
        public Enum? State { get; set; }
        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
