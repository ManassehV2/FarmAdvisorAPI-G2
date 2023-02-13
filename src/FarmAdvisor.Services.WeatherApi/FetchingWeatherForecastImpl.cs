using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using FarmAdvisor.Models.Models;

namespace FarmAdvisor.Services.WeatherApi
{
    public class FetchingWeatherForecastImpl : IFetchingWeatherForecast
    {
        private readonly IWeatherRemoteRepository _weatherRepository;

        public FetchingWeatherForecastImpl(IWeatherRemoteRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        
        public async Task<List<SensorWeatherData>> SensorWeatherForecast(List<Sensor> sensors)
        {
              List<SensorWeatherData> listOfSensorWeatherData = new List<SensorWeatherData>();
        
        const double baseTemperature = -17.2;
        foreach (var sensor in sensors)
        {
            // first call the met api and find the forecast data using it's latitude and
            SensorWeatherData curSensorWeatherData = new SensorWeatherData();
        
            WeatherForecastModel weatherForecastOfCurrentSensor =
                await _weatherRepository.GetForecastData(
                    sensor.Long,
                    sensor.Lat,
                    10
                );
            Console.WriteLine("-----------------------api response----------------");
            Console.WriteLine(weatherForecastOfCurrentSensor);
            
            Dictionary<string, List<double>> temperaturesWithDatesOfCurrentSensor =
                TemperatureWithDateFinder(weatherForecastOfCurrentSensor);
            Console.WriteLine("-----------------------temperaturesWithDatesOfCurrentSensor----------------");
            Console.WriteLine(temperaturesWithDatesOfCurrentSensor);
            
            Dictionary<string, double> gddOfEachDayOfCurrentSensor = GddOfEachDayCalculator(
                temperaturesWithDatesOfCurrentSensor,
                baseTemperature
            );
            Console.WriteLine("-----------------------gddOfEachDayOfCurrentSensor----------------");
            Console.WriteLine(gddOfEachDayOfCurrentSensor);
            
            Dictionary<string, double> averageTemperatureOfCurrentSensor =
                AverageTemperatureOfEachSensor(temperaturesWithDatesOfCurrentSensor);
            Console.WriteLine("-----------------------averageTemperatureOfCurrentSensor----------------");
            Console.WriteLine(averageTemperatureOfCurrentSensor);
            
            curSensorWeatherData.SensorId = (Guid)sensor.SensorId;
            curSensorWeatherData.ForecastGDD = gddOfEachDayOfCurrentSensor;
            curSensorWeatherData.ForecastTemperature = averageTemperatureOfCurrentSensor;
        
            listOfSensorWeatherData.Add(curSensorWeatherData);
        }
        
        return listOfSensorWeatherData;
        }

        public Dictionary<string, List<double>> TemperatureWithDateFinder(
            WeatherForecastModel weather
        )
        {
            Dictionary<string, List<double>> temperatureWithDate =
                new Dictionary<string, List<double>>();

            foreach (var forecast in weather.Properties.Timeseries)
            {
                var time = forecast.Time;
                var todayTemperature = forecast.Data.Instant.Details["air_temperature"];
                var year = time.Year.ToString();
                var month = time.Month.ToString();
                var daily = time.Day.ToString();
                var day = year + "-" + month + "-" + daily;
                if (temperatureWithDate.ContainsKey(day))
                {
                    temperatureWithDate[day].Add(todayTemperature);
                }
                else
                {
                    temperatureWithDate.Add(day, new List<double>());
                    temperatureWithDate[day].Add(todayTemperature);
                }
            }
            return temperatureWithDate;
        }

        // This function accepts date:List<temperature> temperature of 24 hours
        // it returns a dictionary date:doubld(gdd of the day)
        public Dictionary<string, double> GddOfEachDayCalculator(
            Dictionary<string, List<double>> temperatureWithDate,
            double baseTemperature
        )
        {
            Dictionary<string, double> gddForecastOfEachDay = new Dictionary<string, double>();
            foreach (var kvp in temperatureWithDate)
            {
                double minTemperature = kvp.Value.Min();
                double maxTemperature = kvp.Value.Max();
                double todayGdd = (minTemperature + maxTemperature) / 2 - baseTemperature;
                List<double> finalGdd = new List<double> { 0.0, todayGdd };
                gddForecastOfEachDay.Add(kvp.Key, finalGdd.Max());
            }

            return gddForecastOfEachDay;
        }
        
        // This function accepts date:List<temperature> temperature of 24 hours
        //  returns a dictionary of data:double[average temperature of that day]
        private static Dictionary<string, double> AverageTemperatureOfEachSensor(
            Dictionary<string, List<double>> temperatureWithDate
        )
        {
            Dictionary<string, double> averageTemperatureOfEachDay =
                new Dictionary<string, double>();
            foreach (var kvp in temperatureWithDate)
            {
                double totalTemperature = kvp.Value.Sum();
                double averageTemperature = totalTemperature / kvp.Value.Count;
                averageTemperatureOfEachDay.Add(kvp.Key, averageTemperature);
            }

            return averageTemperatureOfEachDay;
        }

        private static int AverageForecastedGddCalculator(
            Dictionary<string, double> gddForecastOfEachDay
        )
        {
            double totalGdd = gddForecastOfEachDay.Values.Sum();
            double averageGdd = totalGdd / gddForecastOfEachDay.Count;
            return Convert.ToInt32(averageGdd);
        }

   
    }

 
}
