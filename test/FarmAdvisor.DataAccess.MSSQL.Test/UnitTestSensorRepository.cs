using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;


namespace FarmAdvisor.DataAccess.MSSQL.Test
{
    public class UnitTestSensorRepository
    {

        private readonly IUnitOfWork UnitOfWork;
        public UnitTestSensorRepository()
        {
            UnitOfWork = UnitOfWorkGenerator.Generate();
        }


        [Fact]
        public async void AddSensor_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("0920394839");
            var farm = new FarmDto("farmName", 8,30);
            var farmFeild = new FarmFieldDto("farmFeildName", 89, farm.FarmId);
            var sensor = new SensorDto("serialNo", 89,89,400, farmFeild.FieldId, DateTime.Now, DateTime.Now);
            await UnitOfWork.SensorRepository.AddAsync(sensor);
            UnitOfWork.SaveChanges();
            var sensors = await UnitOfWork.SensorRepository.GetAllAsync();
            UnitOfWork.DisposeContext();
            
            Assert.Single(sensors);


        }


        [Fact]
        public async void GetSensorById_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("0920394839");
            var farm = new FarmDto("farmName", 8,30);
            var farmFeild = new FarmFieldDto("farmFeildName", 89, farm.FarmId);
            var sensor = new SensorDto("serialNo", 89,89,400, farmFeild.FieldId, DateTime.Now, DateTime.Now);
            await UnitOfWork.SensorRepository.AddAsync(sensor);
            UnitOfWork.SaveChanges();
            var result = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.DisposeContext();
            
            Assert.NotNull( result);

        }


        [Fact]
        public async void UpdateSensor_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);

            var user = new UserDto("0920394839");
            var farm = new FarmDto("farmName", 8,30);
            var farmFeild = new FarmFieldDto("farmFeildName", 89, farm.FarmId);
            var gdd = 0;
            var sensor = new SensorDto("serialNo", 8, 30, gdd, farmFeild.FieldId, DateTime.Now, DateTime.Now);
            await UnitOfWork.SensorRepository.AddAsync(sensor);
            UnitOfWork.SaveChanges();
            var sensorBeforeUpdate = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            // manual update sensor
            sensorBeforeUpdate!.OptimalGDD = 400;
            await UnitOfWork.SensorRepository.UpdateAsync(sensorBeforeUpdate);
            UnitOfWork.SaveChanges();
            var sensorAfterUpdate = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Assert.NotEqual(gdd, sensorAfterUpdate!.OptimalGDD);

            
              
        }


        [Fact]
        public async void DeleteSensor_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("0920394839");
            var farm = new FarmDto("farmName", 8,30);
            var farmFeild = new FarmFieldDto("farmFeildName", 89, farm.FarmId);
            var sensor = new SensorDto("serialNo", 89,89,400, farmFeild.FieldId, DateTime.Now, DateTime.Now);
            await UnitOfWork.SensorRepository.AddAsync(sensor);
            var sensorBeforeDelete = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Assert.NotNull(sensorBeforeDelete);
            await UnitOfWork.SensorRepository.DeleteAsync(sensorBeforeDelete!);
            var sensorAfterDelete = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.DisposeContext();
            Assert.Null(sensorAfterDelete);
            
        }
    }
    }