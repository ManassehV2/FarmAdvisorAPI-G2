using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public enum State
    {
        
        OK = 0,
        BATTERYLOW = 1,

    
    }
    public class SensorDto
    {
        [Key]
        public Guid SensorId { get; set; }
        public string? SerialNo { get; set; }
        public DateTime LastCommunication { get; set; }
        public int BatteryStatus { get; set; }
        public int OptimalGDD { get; set; }
        public DateTime CuttingDateCaclculated { get; set; }
        public DateTime LastForecastDate { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public State State { get; set; }

        // Navigation Properties        
        [ForeignKey("Feild")]
        public Guid FeildId { get; set; }
        public FarmFieldDto? Feild { get; set; }
        public SensorResetDateDto? ResetDate { get; set; }

    }
}