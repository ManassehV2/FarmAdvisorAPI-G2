namespace FarmAdvisor.Models.Models;

public class SensorWeatherData
{
    public Guid SensorId;
    public Dictionary<string, double> ForecastTemperature;
    public Dictionary<string, double> ForecastGDD;
}