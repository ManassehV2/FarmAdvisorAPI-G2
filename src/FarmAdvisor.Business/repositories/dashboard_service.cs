using FarmAdvisor.DataAccess.AzureTableStorage.Services;
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.Models.Models;

namespace FarmAdvisor.Business
{

    public class DashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastStorage _weatherForecast;

        public DashboardService(IUnitOfWork unitOfWork, IWeatherForecastStorage weatherForecast)
        {
            _unitOfWork = unitOfWork;
            _weatherForecast = weatherForecast;
        }
        
        public async ValueTask<BoardInfoModel> GetDashboardInfo(Guid fieldId){
            try{
                var farmFieldDto = await _unitOfWork.FarmFeildRepository.GetByIdAsync(fieldId);
                var sensorDtos = await _unitOfWork.SensorRepository.GetSensorByFieldId(fieldId);
                
                var sensors = sensorDtos.Select(
                    newSensor => new Sensor(
                        newSensor.SensorId,
                        newSensor.SerialNo,
                        newSensor.Long,
                        newSensor.Lat,
                        newSensor.OptimalGDD,
                        newSensor.FeildId,
                        newSensor.LastCuttingDate,
                        newSensor.LastCommunication
                    )
                );
                List<Sensor> sensorsData = sensors.ToList();
                FarmFieldModel farmField = new FarmFieldModel(
                    farmFieldDto.FieldId, 
                    farmFieldDto.Name, 
                    (decimal)farmFieldDto.Altitude, 
                    farmFieldDto.FarmId);
                // Fetch weather forcast from azure table
                // date: [averageTemp, gdd]
                Dictionary<string, List<double>> forcastData = new Dictionary<string, List<double>>();
                
                for (int j=0; j<sensorsData.Count; j++)
                {
                    Console.WriteLine($"senor count {j}");
                    DateTime today = DateTime.Now;
                    int day = Convert.ToInt32(today.Day);
                    string month = today.Month.ToString();
                    string year = today.Year.ToString();
                    Sensor sensor = sensorsData[j];
                    for (int i = 0; i < 10; i++)
                    {
                        string d = day.ToString();
                        string date = year + "-" + month + "-" + d;
                        day += 1;
                        var result = await _weatherForecast.GetEntityAsync(sensor.SensorId.ToString(), date);
                        List<double> value = new List<double>();
                        value.Add(result.calculatedTemperature);
                        value.Add(result.calculatedGdd);
                        
                        forcastData.Add(result.RowKey, value);
                    }
                }
               
                
                return new BoardInfoModel(
                    null,
                    farmField,
                    sensorsData,
                    forcastData,
                    forcastData
                );
                
            }catch(Exception e){
                throw e;
            }
        }

        public async ValueTask<Dictionary<string, double>> GetDashboardStatistics(Guid fieldId, string startDate, string endDate){
            try{
                var farmFieldDto = await _unitOfWork.FarmFeildRepository.GetByIdAsync(fieldId);
                var sensorDtos = await _unitOfWork.SensorRepository.GetSensorByFieldId(fieldId);
                
                var sensors = sensorDtos.Select(
                    newSensor => new Sensor(
                        newSensor.SensorId,
                        newSensor.SerialNo,
                        newSensor.Long,
                        newSensor.Lat,
                        newSensor.OptimalGDD,
                        newSensor.FeildId,
                        newSensor.LastCuttingDate,
                        newSensor.LastCommunication
                    )
                );
                List<Sensor> sensorsData = sensors.ToList();
                Dictionary<string, double> statData = new Dictionary<string, double>();
                
                
                    string[] beginDate = startDate.Split("-");
                    string[] finalDate = endDate.Split("-");
                    int startday = Convert.ToInt32(beginDate[2]);
                    int endday = Convert.ToInt32(finalDate[2]);
                    string month = beginDate[1];
                    string year = beginDate[0];
                    Sensor sensor = sensorsData[0];
                    
                    for (int i = startday; i <= endday; i++)
                    {
                        string d = i.ToString();
                        string date = year + "-" + month + "-" + d;
                        var result = await _weatherForecast.GetEntityAsync(sensor.SensorId.ToString(), date);

                        statData.Add(result.RowKey, result.calculatedTemperature);
                    }

                    return statData;

            }catch(Exception e){
                throw e;
            }
        }
    }
}