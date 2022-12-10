
using FarmAdvisor.Models.Models;


namespace FarmAdvisor.Services.WeatherApi{
    public static class Utils
        {
            public static List<Sensor> GenerateSensors()
            {
                List<Sensor> sensors= new List<Sensor>();
                foreach(var i in Enumerable.Range(1, 9))
                {
                    var sensor = new Sensor{
                        SensorId = Guid.NewGuid(),
                        SerialNo = String.Format("serial{0}", i),
                        LastCommunication = DateTime.Now,
                        BatteryStatus = 1,
                        OptimalGDD = 300 + i,
                        CuttingDateCaclculated = DateTime.Now,
                        LastForecastDate = DateTime.Now,
                        Long = 38 + i / 10,
                        Lat = 8.5 + i / 10,
                        State = State.OK
                    };

                    sensors.Add(sensor);
                }

                return sensors;

            }
        }
}

