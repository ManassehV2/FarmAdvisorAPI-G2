
namespace FarmAdvisor.Models.Models

{
    public enum State
    {
        
        OK = 0,
        BATTERYLOW = 1,

    
    }
    public class Sensor
    {
        public Sensor() { }
        public Sensor(Guid sensorId, string serialNo, DateTime lastCommunication, int batteryStatus, int optimalGDD, DateTime cuttingDateCaclculated, DateTime lastForecastDate, double @long, double lat, State state, Guid fieldId)
        {
            SensorId = sensorId;
            SerialNo = serialNo;
            LastCommunication = lastCommunication;
            BatteryStatus = batteryStatus;
            OptimalGDD = optimalGDD;
            CuttingDateCaclculated = cuttingDateCaclculated;
            LastForecastDate = lastForecastDate;
            Long = @long;
            Lat = lat;
            State = state;
            FieldId = fieldId;

        }
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
        public Guid FieldId { get; set; }

    }


}