using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;


namespace FarmAdvisor.DataAccess.MSSQL.Test
{
    public class UnitTestSensorResetDateRepository
    {

        private readonly IUnitOfWork UnitOfWork;
        public UnitTestSensorResetDateRepository()
        {
            UnitOfWork = UnitOfWorkGenerator.Generate();
        }


        [Fact]
        public async void AddSensorResetData_Success_Test()
        {
            
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("0920394839");
            var farm = new FarmDto("farmName", 8,30);
            var farmFeild = new FarmFieldDto("farmFeildName", 89, farm.FarmId);
            var sensor = new SensorDto("serialNo", 89,89,400, farmFeild.FieldId, DateTime.Now, DateTime.Now);
            var sensorResetDate = new SensorResetDateDto(sensor.SensorId, DateTime.Now);
            await UnitOfWork.SensorResetDateRepository.AddAsync(sensorResetDate);
            var result = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            
            UnitOfWork.DisposeContext();
            Assert.Equal(sensorResetDate, result);
            


        }


        [Fact]
        public async void GetSensorResetDateById_Success_Test()
        {
            
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("0920394839");
            var farm = new FarmDto("farmName", 8,30);
            var farmFeild = new FarmFieldDto("farmFeildName", 89, farm.FarmId);
            var sensor = new SensorDto("serialNo", 89,89,400, farmFeild.FieldId, DateTime.Now, DateTime.Now);
            var sensorResetDate = new SensorResetDateDto(sensor.SensorId, DateTime.Now);
            await UnitOfWork.SensorResetDateRepository.AddAsync(sensorResetDate);
            UnitOfWork.SaveChanges();
            var result = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            Assert.NotNull(result);
            
        }


    }}