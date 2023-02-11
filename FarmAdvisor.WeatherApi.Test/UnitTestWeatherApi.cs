/*using FarmAdvisor.Models.Models;
using FarmAdvisor.Services.WeatherApi;

namespace weatherApi.Test
{
    public class UnitTestWeatherRemoteRepository
    {
        public static HttpClient _client = new HttpClient();
        public static IWeatherRemoteRepository _repository = new WeatherRemoteRepositoryImpl(_client);
        public FetchingWeatherForecast _fetchingWeatherForecast = new FetchingWeatherForecast((WeatherRemoteRepositoryImpl)_repository);
        
        public UnitTestWeatherRemoteRepository()
        {
            _repository = A.Fake<IWeatherRemoteRepository>();
        }


        

        [Fact]
        public async void TestName()
        {
            var timeToTemprature = new Dictionary<string, List<double>>();
            var baseTemp = -17.2;
            for (int i = 0; i < 10; i++)
            {   
                var hour = DateTime.Now.ToString() + i.ToString();
                var hours = new List<double>();
                for (int j = 0; j < 24; j++)
                {
                    hours.Add(j * 2.0);
                }

                timeToTemprature.Add(hour, hours);

            }

            var result = _fetchingWeatherForecast.GddOfEachDayCalculator(timeToTemprature, baseTemp);

            Assert.Equal(10, result.Count);
            Assert.Equal(10, result.Values.Count);
            Assert.NotNull(result);
            
        }
        

    }
}*/