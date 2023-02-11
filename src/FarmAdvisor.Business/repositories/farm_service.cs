using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;
using FarmAdvisor.Models.Models;

namespace FarmAdvisor.Business{

    public class FarmService{

        private readonly IUnitOfWork _unitOfWork;

        public FarmService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }

        //add farm
        public void AddFarm(Farm farm){
            try{
                var farmDto = new FarmDto(farm.FarmId, farm.Name, farm.UserId, farm.Postcode, farm.City, farm.Country);
                _unitOfWork.FarmRepository.AddAsync(farmDto);
                _unitOfWork.SaveChanges();
            }catch(Exception e){
                throw e;
            }
        }

        //get farm
        public async ValueTask<Farm> GetFarm(Guid farmId){
            try{
                var farmDto = await _unitOfWork.FarmRepository.GetByIdAsync(farmId);
                return new Farm(farmDto.FarmId, farmDto.Name, farmDto.Postcode, farmDto.City, farmDto.Country, farmDto.UserId,
                 farmDto.FarmFeilds.Select(
                    farmFieldDto => new FarmFieldModel(
                        farmFieldDto.FieldId, farmFieldDto.Name, (decimal)farmFieldDto.Altitude, farmFieldDto.Polygon, farmFieldDto.FarmId))
                        .ToList());
            }catch(Exception e){
                throw e;
            }
        }

        // get fields in a farm
        public async ValueTask<IEnumerable<FarmFieldModel>> GetFarmFields(Guid farmId){
            try{
                var farmDto = await _unitOfWork.FarmRepository.GetByIdAsync(farmId);
                return farmDto.FarmFeilds.Select(
                    farmFieldDto => new FarmFieldModel(
                        farmFieldDto.FieldId, farmFieldDto.Name, (decimal)farmFieldDto.Altitude, farmFieldDto.Polygon, farmFieldDto.FarmId));
            }catch(Exception e){
                throw e;
            }
        }

        // get all farms
        public async ValueTask<IEnumerable<Farm>> GetAllFarms(){
            try{
                var farmDtos = await _unitOfWork.FarmRepository.GetAllAsync();
                var farms = farmDtos.Select(farmDto => new Farm(farmDto.FarmId, farmDto.Name, farmDto.Postcode, farmDto.City, farmDto.Country, farmDto.UserId,
                 farmDto.FarmFeilds.Select(
                    farmFieldDto => new FarmFieldModel(
                        farmFieldDto.FieldId, farmFieldDto.Name, (decimal)farmFieldDto.Altitude, farmFieldDto.Polygon, farmFieldDto.FarmId))
                        .ToList()));
                return farms;
            }catch(Exception e){
                throw e;
            }
        }

        //delete farm
        public async ValueTask<Farm> DeleteFarm(Guid farmId){
            try{
                var farmDto = await _unitOfWork.FarmRepository.GetByIdAsync(farmId);
                var farm = new Farm(farmDto.FarmId, farmDto.Name, farmDto.Postcode, farmDto.City, farmDto.Country, farmDto.UserId,
                 farmDto.FarmFeilds.Select(
                    farmFieldDto => new FarmFieldModel(
                        farmFieldDto.FieldId, farmFieldDto.Name, (decimal)farmFieldDto.Altitude, farmFieldDto.Polygon, farmFieldDto.FarmId))
                        .ToList());
                _unitOfWork.FarmRepository.DeleteAsync(farmDto);
                _unitOfWork.SaveChanges();
                return farm;
            }catch(Exception e){
                throw e;
            }
        }

    }
}