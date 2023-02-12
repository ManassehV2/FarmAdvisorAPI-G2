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
                sensor.SerialNo, 
                sensor.Long,
                sensor.Lat,
                sensor.OptimalGDD,
                sensor.FieldId,
                sensor.LastCuttingDate,
                sensor.LastCommunication
                );

            var newSensor = await _unitOfWork.SensorRepository.AddAsync(sensorDto);
            _unitOfWork.SaveChanges();
            return new Sensor(
                newSensor.SensorId,
                newSensor.SerialNo,
                newSensor.Long,
                newSensor.Lat,
                newSensor.OptimalGDD,
                newSensor.FeildId,
                newSensor.LastCuttingDate,
                newSensor.LastCommunication

                );
             
            
        }catch(Exception e){
            throw e;
        }
    } 

    public async ValueTask<Sensor> GetSensorById(Guid sensorId){
        try{
            var newSensor = await _unitOfWork.SensorRepository.GetByIdAsync(sensorId);
            var sensor = new Sensor(
                newSensor.SensorId,
                newSensor.SerialNo,
                newSensor.Long,
                newSensor.Lat,
                newSensor.OptimalGDD,
                newSensor.FeildId,
                newSensor.LastCuttingDate,
                newSensor.LastCommunication
            );
            return sensor;
        }catch(Exception ex){
            throw ex;
        }
    }


    // get sensors by fieldId
    public async ValueTask<IEnumerable<Sensor>> GetSensorByFieldId(Guid fieldId){
            try{
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

                return sensors;
            }catch(Exception e){
                throw e;
            }
        }

    

    }
}