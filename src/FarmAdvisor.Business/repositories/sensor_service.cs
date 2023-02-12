using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;
using FarmAdvisor.Models.Models;

namespace FarmAdvisor.Business{

    public class SensorService{
        private readonly IUnitOfWork _unitOfWork;

        public SensorService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
    

    // create sensor
    public async ValueTask<Sensor> CreateSensor(Sensor sensor){
        try{
            var  sensorDto = new SensorDto(
                sensor.SensorId, 
                sensor.SerialNo, 
                sensor.LastCommunication, 
                sensor.BatteryStatus, 
                sensor.OptimalGDD,
                sensor.CuttingDateCaclculated,
                sensor.LastCommunication,
                sensor.Long,
                sensor.Lat,
                DataAccess.MSSQL.Dtos.State.OK,
                sensor.FieldId

                );

            var newSensor = await _unitOfWork.SensorRepository.AddAsync(sensorDto);
            _unitOfWork.SaveChanges();
            return new Sensor(
                newSensor.SensorId,
                newSensor.SerialNo,
                newSensor.LastCommunication,
                newSensor.BatteryStatus,
                newSensor.OptimalGDD,
                newSensor.CuttingDateCaclculated,
                newSensor.LastCommunication,
                newSensor.Long,
                newSensor.Lat,
                Models.Models.State.OK,
                newSensor.FeildId
                );
            
        }catch(Exception e){
            throw e;
        }
    } 
    }
}