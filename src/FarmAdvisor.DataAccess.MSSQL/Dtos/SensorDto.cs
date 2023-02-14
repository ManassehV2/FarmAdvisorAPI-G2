using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    
    public class SensorDto
    {

        

        public SensorDto(string serialNo,  double @long, double lat,int optimalGDD ,Guid feildId, DateTime lastCuttingDate, DateTime lastCommunication)
        {
            SensorId = new Guid();
            SerialNo = serialNo;
            Long = @long;
            Lat = lat;
            OptimalGDD = optimalGDD;
            FeildId = feildId;
            LastCuttingDate = lastCuttingDate;
            LastCommunication = lastCommunication;

        }
        
        [Key]
        public Guid SensorId { get; set; }
        public string SerialNo { get; set; }
        public DateTime LastCommunication { get; set; }
        public int? BatteryStatus { get; set; }
        public int OptimalGDD { get; set; }
        public DateTime LastCuttingDate { get; set; }
        public DateTime? CuttingDateCaclculated { get; set; }
        public DateTime? LastForecastDate { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public int CurrentGDD { get; set; }
        public List<SensorResetDateDto>? ResetDate { get; set; }

        // Navigation Properties        
        [ForeignKey("Feild")]
        public Guid FeildId { get; set; }
        public FarmFieldDto? Feild { get; set; }
        

    }
}



