namespace FarmAdvisor.Models.Models
{
    public enum State
    {
        
        OK,
        Warning
    
    }
    public class Sensor
    {
       public Guid SensorId { get; set; }
        public Guid FieldId { get; set; }
        public string SerialNo { get; set; }
        public DateTime LastCommunication { get; set; }
        public int BatteryStatus { get; set; }
        public int OptimalGDD { get; set; }
        public DateTime CuttingDateCaclculated { get; set; }
        public DateTime LastForecastDate { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public State State { get; set; }

        public Guid FarmFeildId { get; set; }
        public FarmFieldModel FarmField { get; set; }

    }
}