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
            
            var farm = DtoGenerator.GenerateFarmDto();
            var sensor = DtoGenerator.GenerateSensorDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            var sensorResetDate = DtoGenerator.GenerateSensorResetDateDto();

            sensor.ResetDate = sensorResetDate;
            sensorResetDate.Sensor = sensor;
            sensorResetDate.SensorId = sensor.SensorId;
    
            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);

            await UnitOfWork.FarmRepository.AddAsync(farm);
            var result = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            UnitOfWork.DisposeContext();

            
            Assert.Equal(sensorResetDate, result);
            


        }


        [Fact]
        public async void GetSensorResetDateById_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            
            var farm = DtoGenerator.GenerateFarmDto();
            var sensor = DtoGenerator.GenerateSensorDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            var sensorResetDate = DtoGenerator.GenerateSensorResetDateDto();

            sensor.ResetDate = sensorResetDate;
            sensorResetDate.Sensor = sensor;
            sensorResetDate.SensorId = sensor.SensorId;
    
            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);

            await UnitOfWork.FarmRepository.AddAsync(farm);

            var resultBeforeDelete = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            Assert.Equal(sensorResetDate, resultBeforeDelete);
            await UnitOfWork.SensorResetDateRepository.DeleteAsync(sensorResetDate);
            var resultAfterDelete = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            Assert.Null(resultAfterDelete);
            UnitOfWork.DisposeContext();
            
        }


        [Fact]
        public async void GetAllSensorResetDates_Success_Test()
        {
            // clean database
            Utils.clearDatabase(UnitOfWork);
            
            // populate database
            var farm = DtoGenerator.GenerateFarmDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            int numberOfSensorResetDateCount = 10;
            foreach(int i in Enumerable.Range(0, numberOfSensorResetDateCount))
            {
                var sensor = DtoGenerator.GenerateSensorDto();
                var sensorResetDate = DtoGenerator.GenerateSensorResetDateDto();
                sensor.ResetDate = sensorResetDate;
                sensorResetDate.Sensor = sensor;
                sensorResetDate.SensorId = sensor.SensorId;
                farmFeild.Sensors!.Add(sensor);
            }
            
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            // test GetAll
            var result = await UnitOfWork.SensorResetDateRepository.GetAllAsync();
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.DisposeContext();
            Assert.Equal(numberOfSensorResetDateCount, result.Count);
            
        }


        [Fact]
        public async void UpdateSensorResetDate_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);

            var farm = DtoGenerator.GenerateFarmDto();
            var sensor = DtoGenerator.GenerateSensorDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            var sensorResetDate = DtoGenerator.GenerateSensorResetDateDto();

            sensor.ResetDate = sensorResetDate;
            sensorResetDate.Sensor = sensor;
            sensorResetDate.SensorId = sensor.SensorId;
    
            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);

            await UnitOfWork.FarmRepository.AddAsync(farm);

            var sensorResetDateBeforeUpdate = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);


            // manual update sensor
            sensorResetDateBeforeUpdate!.TimeStamp = DateTime.Now;
            await UnitOfWork.SensorResetDateRepository.UpdateAsync(sensorResetDateBeforeUpdate);

            var sensorResetDateAfterUpdate = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);

            Assert.Equal(sensorResetDateBeforeUpdate, sensorResetDateAfterUpdate);

            
              
        }


        [Fact]
        public async void DeleteSensorResetDate_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var farm = DtoGenerator.GenerateFarmDto();
            var sensor = DtoGenerator.GenerateSensorDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            var sensorResetDate = DtoGenerator.GenerateSensorResetDateDto();

            sensor.ResetDate = sensorResetDate;
            sensorResetDate.Sensor = sensor;
            sensorResetDate.SensorId = sensor.SensorId;
    
            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);

            await UnitOfWork.FarmRepository.AddAsync(farm);

            var sensorResetDateBeforeDelete = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            Assert.NotNull(sensorResetDateBeforeDelete);
            await UnitOfWork.SensorResetDateRepository.DeleteAsync(sensorResetDate);
            var sensorResetDateAfterDelete = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            Assert.Null(sensorResetDateAfterDelete);
            UnitOfWork.DisposeContext();
            
        }


        [Fact]
        public async void Relation_Success_Test()
        {

            Utils.clearDatabase(UnitOfWork);
            
            var farm = DtoGenerator.GenerateFarmDto();
            var sensor = DtoGenerator.GenerateSensorDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            var sensorResetDate = DtoGenerator.GenerateSensorResetDateDto();

            sensor.ResetDate = sensorResetDate;
            sensorResetDate.Sensor = sensor;
            sensorResetDate.SensorId = sensor.SensorId;
    
            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);

            await UnitOfWork.FarmRepository.AddAsync(farm);

            var sensorResetDateAfterAdd = await UnitOfWork.SensorResetDateRepository.GetByIdAsync(sensorResetDate.ResetDateId);
            Assert.NotNull(sensorResetDateAfterAdd);
            Assert.NotNull(sensorResetDateAfterAdd!.Sensor);

            await UnitOfWork.SensorResetDateRepository.DeleteAsync(sensorResetDate);
            var sensorAfterDeleteResetDate = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Assert.Null(sensorAfterDeleteResetDate!.ResetDate);
            UnitOfWork.DisposeContext();
        }

        

        
    }
}