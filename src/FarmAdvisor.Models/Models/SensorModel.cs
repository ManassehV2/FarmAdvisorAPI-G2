
namespace FarmAdvisor.Models.Models

{
    
    public class Sensor
    {
        
        public Sensor(Guid? sensorId, string serialNo,  double @long, double lat,int defaultGDD ,Guid fieldId, DateTime lastCuttingDate, DateTime lastCommunication )
        {
            SensorId = sensorId;
            SerialNo = serialNo;
            Long = @long;
            Lat = lat;
            OptimalGDD = defaultGDD;
            FieldId = fieldId;
            LastCuttingDate = lastCuttingDate;
            LastCommunication = lastCommunication;

        }
       
        public Guid? SensorId { get; set; }
        public string? SerialNo { get; set; }
        public DateTime LastCommunication { get; set; }
        public int? BatteryStatus { get; set; }
        public int OptimalGDD { get; set; }
        public DateTime? CuttingDateCaclculated { get; set; }
        public DateTime? LastForecastDate { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public Guid FieldId { get; set; }
        public DateTime LastCuttingDate { get; set; }
        public int CurrentGDD { get; set; } = 0;

    }


}