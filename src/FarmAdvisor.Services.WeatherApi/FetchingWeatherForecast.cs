using System.Net.Http.Headers;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using FarmAdvisor.Models.Models;


namespace FarmAdvisor.Services.WeatherApi
{
    public class FetchingWeatherForecast
    {
        private readonly ILogger<FetchingWeatherForecast> _logger;
        private readonly HttpClient _httpClient;

       
        public FetchingWeatherForecast(ILogger<FetchingWeatherForecast> logger, HttpClient httpclient)
        {
            _logger = logger;
            _httpClient = httpclient;
        }
        
        /*
         * Target:
         * 1. Call an api request for each sensor and find the forecast information
         * 2. For each sensor we will return a class which contain the information
         *        . sensor id
         *        . List of Dictionary<date, averageTemperature>
         *        . List of Dictionary<date, averageTemperature>
         *    and return this data from this class using a function.
         * 
         * 3. So, return List<SensorWeatherData> from this class
         */
        
        
        /*
         * Functions needed:
         * 1. A function that accepts latitude and longitude as parameter and calls the met api using it's parameters.
         *      and returns a WeatherForecastModel.
         * 2. There is another function that accepts the WeatherForecastModel data and returns a dictionary of
         *      Dictionary<date, List<temperature>>
         * 3. There is another function that accepts the Dictionary<date, List<temperature>> data and return
         *      Dictionary<date, GDD>
         * 4. There is another function that accepts Dictionary<date, List<temperature>> and returns
         *      Dictionary<date, averageTemperature>
         *
         *  at the end using . sensor id
         *                   . Dictionary<date, GDD>
         *                   . Dictionary<date, averageTemperature>
         *   create the object and accumulate as a list and return it
         */
        
        /*
         * Here is the main function that is called from this class
         *  Accepts: List<Sensors>
         *
         *  returns: List<SensorWeatherData>
         */

        public static async Task<List<SensorWeatherData>> SensorWeatherForecast()
        {
            // // List<string> sensores = CallConvMemberFunction():
            //     
            List<SensorWeatherData> listOfSensorWeatherData = new List<SensorWeatherData>();
            // const double baseTemperature = -17.2;
            // foreach (var sensor in sensores)
            // {
            //     // first call the met api and find the forecast data using it's latitude and 
            //     SensorWeatherData curSensorWeatherData = new SensorWeatherData();
            //     
            //     // WeatherForecastModel weatherForecastOfCurrentSensor = GetForecastData(23.1, 12.3);
            //
            //     Dictionary<string, List<double>> temperaturesWithDatesOfCurrentSensor =  TemperatureWithDateFinder(weatherForecastOfCurrentSensor);
            //     
            //     Dictionary<string, double> gddOfEachDayOfCurrentSensor =
            //     GddOfEachDayCalculator(temperaturesWithDatesOfCurrentSensor, baseTemperature);
            //
            //     Dictionary<string, double> averageTemperatureOfCurrentSensor = AverageTemperatureOfEachSensor(
            //         temperaturesWithDatesOfCurrentSensor);
            //
            //     curSensorWeatherData.SensorId = sensor.Id;
            //     curSensorWeatherData.ForecastGDD = gddOfEachDayOfCurrentSensor;
            //     curSensorWeatherData.ForecastTemperature = averageTemperatureOfCurrentSensor;
            //     
            //     listOfSensorWeatherData.Add(curSensorWeatherData);
            // }
            //
            return listOfSensorWeatherData;
            
        }
        
        
        
        /*
         * Implement this http request and create a DTO using the model from FarmAdvisor.Model folder
         */
        public  async Task<WeatherForecastModel> GetForecastData(double latitude, double longitude)
        {
            var url =
                "https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=60.10&lon=9.58";
            _httpClient.DefaultRequestHeaders.Add("User-Agent" ,"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36");
            try
            {
                WeatherForecastModel? result = await _httpClient.GetFromJsonAsync<WeatherForecastModel>(url);
                
                return result;

            }
            catch (HttpRequestException)
            {
                return null;
            }
            
        }
        
        
        /*
         * This is the First Major function that 
         *
         * Accept: WeatherForecastModel
         *
         * return Dictionary<date, List<temperature>>
         * 
         */
        private static Dictionary<string, List<double>> TemperatureWithDateFinder(WeatherForecastModel weather)
        {
            Dictionary<string, List<double>> temperatureWithDate =
                new Dictionary<string, List<double>>();
            
            foreach (var forecast in weather.Properties.Timeseries)
            {
                var time = forecast.Time;
                var todayTemperature = forecast.Data.Instant.Details.AirTemperature;
                var day = time.Day.ToString();
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
        
        /*
         * This is the second Major function that 
         *
         * Accept: Dictionary<date, List<temperature>> and Base Temperature of crop
         *
         * return Dictionary<date, GDD>
         * 
         */
        private static Dictionary<string, double> GddOfEachDayCalculator(
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

        private static Dictionary<string, double> AverageTemperatureOfEachSensor(
            Dictionary<string, List<double>> temperatureWithDate)
        {
            Dictionary<string, double> averageTemperatureOfEachDay = new Dictionary<string, double>();
            foreach (var kvp in temperatureWithDate)
            {
                double totalTemperature = kvp.Value.Sum();
                double averageTemperature = totalTemperature / kvp.Value.Count;
                averageTemperatureOfEachDay.Add(kvp.Key, averageTemperature);
            }

            return averageTemperatureOfEachDay;
        }
        
        

        private static int AverageForecastedGddCalculator(Dictionary<string, double> gddForecastOfEachDay)
        {
            double totalGdd = gddForecastOfEachDay.Values.Sum();
            double averageGdd = totalGdd / gddForecastOfEachDay.Count;

            return Convert.ToInt32(averageGdd);
        }
    }
}
