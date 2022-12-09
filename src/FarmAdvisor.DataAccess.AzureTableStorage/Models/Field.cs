using Azure;
using Azure.Data.Tables;
using System;

namespace FarmAdvisorApi.Models
{
    public class FieldEntity : ITableEntity
    {
        public string? FieldId { get; set; }
        public int? FarmId { get; set; }
        public string? Name { get; set; }
        public int Altitude { get; set; }
        public string? Polygon { get; set; }
        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
