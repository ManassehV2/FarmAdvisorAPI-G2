
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace  FarmAdvisor.DataAccess.MSSQL.Test
{
    public static class DtoGenerator
    {

        public static UserDto GenerateUserDto(string number = "1")
        {
            var id = Guid.NewGuid();
            var User = new UserDto
            {
                UserId = Guid.NewGuid(),
                Name = String.Format("Test User {0}", number),
                Email = String.Format("testuser{0}@gmail.com", number),
                AuthId = String.Format("authId{0}", number),
                Farm = null
            };

            return User;
        }

        public static FarmDto GenerateFarmDto(string number = "1")
        {
            var id = Guid.NewGuid();
            var Farm = new FarmDto
            {
                FarmId = Guid.NewGuid(),
                Name = String.Format("Test Farm {0}", number),
                Postcode = String.Format("postcode{0}", number),
                City = String.Format("city{0}", number),
                Country = String.Format("country{0}", number),
                FarmFeilds = new List<FarmFieldDto>(),
                UserId = Guid.NewGuid(),
                User = null,
                Notifications = new List<NotificationDto>()
            };

            return Farm;
        }


        public static FarmFieldDto GenerateFarmFieldDto(string number = "1")
        {
            var id = Guid.NewGuid();
            var FarmField = new FarmFieldDto
            {
                FieldId = Guid.NewGuid(),
                Name = String.Format("Test FarmField {0}", number),
                Altitude = 0,
                Polygon = String.Format("polygon{0}", number),
                FarmId = Guid.NewGuid(),
                Farm = null,
                Sensors = new List<SensorDto>()
            };

            return FarmField;
        }

        public static SensorDto GenerateSensorDto(string number = "1")
        {
            var id = Guid.NewGuid();
            var Sensor = new SensorDto
            {
                SensorId  = Guid.NewGuid(),
                SerialNo = String.Format("Test Sensor {0}", number),
                LastCommunication = DateTime.Now,
                BatteryStatus = 1,
                OptimalGDD = 80,
                CuttingDateCaclculated = DateTime.Now,
                LastForecastDate = DateTime.Now,
                Long = 0,
                Lat = 0,
                State = State.OK,
                FeildId = Guid.NewGuid(),
                Feild = null,
                ResetDate = null


                
            };

            return Sensor;
        }

        public static SensorResetDateDto GenerateSensorResetDateDto(string number = "1")
        {
            
            var SensorResetDate = new SensorResetDateDto
            {
                ResetDateId = Guid.NewGuid(),
                TimeStamp = DateTime.Now,
                SensorId = Guid.NewGuid(),
                Sensor = null
            };

            return SensorResetDate;
        }

        public static NotificationDto GenerateNotificationDto(string number = "1")
        {
            var Notification = new NotificationDto
            {
                NotificationId = Guid.NewGuid(),
                Title = String.Format("Test Notification {0}", number),
                Message = String.Format("Test Notification {0}", number),
                Status = Status.UNREAD,
                FarmId = Guid.NewGuid(),
                Farm = null
            };
        
            return Notification;
        }
        


       

        public static List<UserDto> GenerateUserDtos(int count = 10)
        {
            var users = new List<UserDto>();
            for (int i = 0; i < count; i++)
            {
                users.Add(GenerateUserDto(i.ToString()));
            }

            return users;
        }

        
        
    }
}