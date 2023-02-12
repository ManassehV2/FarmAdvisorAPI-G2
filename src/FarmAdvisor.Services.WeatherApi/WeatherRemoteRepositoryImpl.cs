using System.Net.Http.Json;
using FarmAdvisor.Models.Models;
using Microsoft.Extensions.Logging;

namespace FarmAdvisor.Services.WeatherApi
{
    public class WeatherRemoteRepositoryImpl : IWeatherRemoteRepository
    {
        private HttpClient _httpClient;

        public WeatherRemoteRepositoryImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecastModel> GetForecastData(
            double latitude,
            double longitude,
            double altitude
        )
        {
            var url =
                "https://api.met.no/weatherapi/locationforecast/2.0/complete?lat=-16.516667&lon=-68.166667&altitude=4150";
            _httpClient.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36"
            );

            try
            {
                WeatherForecastModel? result =
                    await _httpClient.GetFromJsonAsync<WeatherForecastModel>(url);

                return result;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
