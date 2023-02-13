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
        public async ValueTask<Farm> AddFarm(Farm farm){
            try{

                var user = await _unitOfWork.UserRepository.GetByIdAsync(farm.UserId);
                var farmDto = new FarmDto(farm.Name, farm.Latitude, farm.Longitude);
                user!.Farm = farmDto;
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.FarmRepository.AddAsync(farmDto);
                _unitOfWork.SaveChanges();
                var createdFarm = await _unitOfWork.FarmRepository.GetByIdAsync(farmDto.FarmId);
                var newFarm =  new Farm(createdFarm.FarmId, createdFarm.Name, createdFarm.LatitudeNum, createdFarm.LongitudeNum, createdFarm.User.UserId);
                
                return newFarm;
            }catch(Exception e){
                throw e;
            }
        }

        //get farm
        public async ValueTask<Farm> GetFarm(Guid farmId){
            try{
                var farmDto = await _unitOfWork.FarmRepository.GetByIdAsync(farmId);
                return new Farm(farmDto.FarmId, farmDto.Name, farmDto.LatitudeNum, farmDto.LongitudeNum,  farmDto.User.UserId);
            }catch(Exception e){
                throw e;
            }
        }

        // get farm by user id
        public async ValueTask<Farm> GetFarmByUserId(Guid userId){
            try{
                var farm = await _unitOfWork.FarmRepository.GetFarmByUserId(userId);
                return new Farm(farm.FarmId, farm.Name, farm.LatitudeNum, farm.LongitudeNum, farm.User.UserId);
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
                        farmFieldDto.FieldId, farmFieldDto.Name, (decimal)farmFieldDto.Altitude, farmFieldDto.FarmId));
            }catch(Exception e){
                throw e;
            }
        }

        // get all farms
        public async ValueTask<IEnumerable<Farm>> GetAllFarms(){
            try{
                var farmDtos = await _unitOfWork.FarmRepository.GetAllAsync();
                var farms = new List<Farm>();
                farmDtos.ForEach(farmDto => farms.Add(new Farm(farmDto.FarmId, farmDto.Name, farmDto.LatitudeNum, farmDto.LongitudeNum, farmDto.User.UserId)));
                return farms;

            }catch(Exception e){
                throw e;
            }
        }

       

    }
}