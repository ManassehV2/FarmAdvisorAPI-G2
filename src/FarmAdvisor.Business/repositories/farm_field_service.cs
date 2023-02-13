using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;
using FarmAdvisor.DataAccess.MSSQL.Implementations;
using FarmAdvisor.Models.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FarmAdvisor.Business{

    public class FarmFieldService{

        private  readonly IUnitOfWork _unitOfWork;

        public FarmFieldService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // create farm field
        public async ValueTask<FarmFieldModel> CreateFarmField(FarmFieldModel farmField){
            try{
                // var farm = await _unitOfWork.FarmRepository.GetByIdAsync(farmField.FarmId);
                var farmFieldDto = new FarmFieldDto(farmField.Name, ((double)farmField.Altitude), farmField.FarmId);
                // if(farm.FarmFeilds == null)
                //     farm.FarmFeilds = new List<FarmFieldDto>();
                // farm.FarmFeilds.Add(farmFieldDto);
                // await _unitOfWork.FarmRepository.UpdateAsync(farm);
                var newField = await _unitOfWork.FarmFeildRepository.AddAsync(farmFieldDto);
                _unitOfWork.SaveChanges();
                return new FarmFieldModel(
                        newField.FarmId,
                        newField.Name,
                        (decimal)newField.Altitude,
                        newField.FarmId);
            }catch(Exception e){
                throw e;
            }
            
        }

        // get farm field
        public async ValueTask<FarmFieldModel> GetFarmField(Guid fieldId){
            try{
                var farmFieldDto = await _unitOfWork.FarmFeildRepository.GetByIdAsync(fieldId);
                return new FarmFieldModel(
                    farmFieldDto.FieldId, 
                    farmFieldDto.Name, 
                    (decimal)farmFieldDto.Altitude, 
                    farmFieldDto.FarmId);
            }catch(Exception e){
                throw e;
            }
        }

        // get all farm fields
        public async ValueTask<IEnumerable<FarmFieldModel>> GetAllFarmFields(){
            try{
                var farmFieldDtos = await _unitOfWork.FarmFeildRepository.GetAllAsync();
                var farmFields = farmFieldDtos.Select(
                    farmFieldDto => new FarmFieldModel(
                        farmFieldDto.FieldId,
                        farmFieldDto.Name,
                        (decimal)farmFieldDto.Altitude, 
                        farmFieldDto.FarmId));

                return farmFields;
            }catch(Exception e){
                throw e;
            }
        }

        // delete farm field
        public async ValueTask<FarmFieldModel> DeleteFarmField(Guid fieldId){
            try{
                var farmFieldDto = await _unitOfWork.FarmFeildRepository.GetByIdAsync(fieldId);
                var farmField = new FarmFieldModel(
                    farmFieldDto.FieldId,
                    farmFieldDto.Name,
                    (decimal)farmFieldDto.Altitude, 
                    farmFieldDto.FarmId);
                _unitOfWork.FarmFeildRepository.DeleteAsync(farmFieldDto);
                _unitOfWork.SaveChanges();
                return farmField;
            }catch(Exception e){
                throw e;
            }
        }

        // get field sensors
        public async ValueTask<List<Sensor>> GetFieldServices(Guid fieldId){
            try{
                var field = await _unitOfWork.FarmFeildRepository.GetByIdAsync(fieldId);
                var sensors = field.Sensors.Select(
                    newSensor => new Sensor(
                        newSensor.SensorId,
                        newSensor.SerialNo,
                        newSensor.Long,
                        newSensor.Lat,
                        newSensor.OptimalGDD,
                        newSensor.FeildId,
                        newSensor.LastCuttingDate,
                        newSensor.LastCommunication
                        
                        )).ToList();
                return sensors;
            }catch(Exception e){
                throw e;
            }

        }


        // get field by farm id
        public async ValueTask<IEnumerable<FarmFieldModel>> GetFarmFieldsByFarmId(Guid farmId){
            try{
                var farmFieldDtos = await _unitOfWork.FarmFeildRepository.GetFarmFieldsByFarmId(farmId);
                var farmFields = farmFieldDtos.Select(
                    farmFieldDto => new FarmFieldModel(
                        farmFieldDto.FieldId,
                        farmFieldDto.Name,
                        (decimal)farmFieldDto.Altitude, 
                        farmFieldDto.FarmId));

                return farmFields;
            }catch(Exception e){
                throw e;
            }
        }

        
    }
}