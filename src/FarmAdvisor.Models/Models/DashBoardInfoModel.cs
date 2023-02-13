namespace FarmAdvisor.Models.Models
{
    public class BoardInfoModel
    {
        public BoardInfoModel(Guid? fieldId, FarmFieldModel fieldModel, List<Sensor> sensors, Dictionary<string, List<double>> weatherForecast, Dictionary<string, List<double>> statistics)
        {
            FieldId = fieldId;
            FieldModel = fieldModel;
            Sensors = sensors;
            WeatherForecast = weatherForecast;
            Statistics = statistics;
        }
        
        public Guid? FieldId { get; set; }
        public FarmFieldModel FieldModel { get; set; }
     
        public List<Sensor> Sensors { get; set; }
        
        public Dictionary<string, List<double>> WeatherForecast { get; set; }
        public Dictionary<string, List<double>> Statistics { get; set; }

    }
}