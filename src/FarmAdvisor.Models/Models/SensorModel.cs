
namespace FarmAdvisor.Models.Models

{
    public enum State
    {
        
        OK = 0,
        BATTERYLOW = 1,

    
    }

    public class Sensor
    {

        public Guid SensorId { get; set; }
        public string? SerialNo { get; set; }
        public DateTime LastCommunication { get; set; }
        public int BatteryStatus { get; set; }
        public int OptimalGDD { get; set; }
        public DateTime CuttingDateCaclculated { get; set; }
        public DateTime LastForecastDate { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public double Altitude { get; set; }

        public State State { get; set; }

    }


}