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
            var farm = DtoGenerator.GenerateFarmDto();
            var sensor = DtoGenerator.GenerateSensorDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();

            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            var farmResult = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            var sensors = await UnitOfWork.SensorRepository.GetAllAsync();
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farmResult! }, UnitOfWork.FarmRepository);
            var sensorsAfterDelete = await UnitOfWork.SensorRepository.GetAllAsync();
            UnitOfWork.Dispose();

            
            Assert.Empty(sensorsAfterDelete);
            Assert.Single(sensors);


        }


        [Fact]
        public async void GetSensorById_Success_Test()
        {   
            var farm = DtoGenerator.GenerateFarmDto();
            var sensor = DtoGenerator.GenerateSensorDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();

            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            sensor.FeildId = farmFeild.FieldId;
            sensor.Feild = farmFeild;


            var result = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.Dispose();
            
            Assert.Equal(sensor, result);

        }


        [Fact]
        public async void GetAllSensors_Success_Test()
        {
            // clean database
            var currentSensors = await UnitOfWork.SensorRepository.GetAllAsync();
            Assert.Empty(currentSensors);

            var farm = DtoGenerator.GenerateFarmDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            // populate database
            int numberOfSensors = 10;

            foreach(int i in Enumerable.Range(0, numberOfSensors))
            {
                var sensor = DtoGenerator.GenerateSensorDto();
                farmFeild.Sensors!.Add(sensor);
            }
            
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            // test GetAll
            var result = await UnitOfWork.SensorRepository.GetAllAsync();
            
            // clean database
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.Dispose();

            Assert.Equal(numberOfSensors, result.Count);
            
        }


        [Fact]
        public async void UpdateSensor_Success_Test()
        {

            var farm = DtoGenerator.GenerateFarmDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            var sensor = DtoGenerator.GenerateSensorDto();

            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            var sensorBeforeUpdate = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);

            // manual update sensor
            sensorBeforeUpdate!.SerialNo = "updatedSerialNo";
            await UnitOfWork.SensorRepository.UpdateAsync(sensorBeforeUpdate);

            var sensorAfterUpdate = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);

            Assert.Equal(sensorBeforeUpdate, sensorAfterUpdate);

            
              
        }


        [Fact]
        public async void DeleteSensor_Success_Test()
        {
            var farm = DtoGenerator.GenerateFarmDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            var sensor = DtoGenerator.GenerateSensorDto();

            farmFeild.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            var fieldBeforeDelete = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);
            var sensorBeforeDelete = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);

            Assert.Single(fieldBeforeDelete!.Sensors!);
            Assert.NotNull(sensorBeforeDelete);

            await UnitOfWork.SensorRepository.DeleteAsync(sensorBeforeDelete!);

            var fieldAfterDelete = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);
            var sensorAfterDelete = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);

            UnitOfWork.Dispose();

            Assert.Empty(fieldAfterDelete!.Sensors!);
            Assert.Null(sensorAfterDelete);
            
        }


        [Fact]
        public async void Relation_Success_Test()
        {
            
            var farm = DtoGenerator.GenerateFarmDto();
            var farmField = DtoGenerator.GenerateFarmFieldDto();
            var sensor = DtoGenerator.GenerateSensorDto();

            farmField.Sensors!.Add(sensor);
            farm.FarmFeilds!.Add(farmField);
            await UnitOfWork.FarmRepository.AddAsync(farm);
            

            var sensorBeforeDeleteFarm = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            Assert.NotNull(sensorBeforeDeleteFarm);

            await UnitOfWork.FarmRepository.DeleteAsync(farm);
            var sensorAfterDeleteFarm = await UnitOfWork.SensorRepository.GetByIdAsync(sensor.SensorId);
            UnitOfWork.Dispose();


            Assert.Null(sensorAfterDeleteFarm);


        }

        

        
    }
}