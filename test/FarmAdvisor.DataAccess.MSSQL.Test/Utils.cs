using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Test
{

    public static class Utils
    {
        public static void DeleteAll<T>(List<T> entities,  IGenericRepository<T> repository) where T : class
        {
            entities.ForEach(async entity => await repository.DeleteAsync(entity));
        }

        public static async void clearDatabase(IUnitOfWork UnitOfWork)
        {
            var currentUsers = await UnitOfWork.UserRepository.GetAllAsync();
            Utils.DeleteAll<UserDto>(currentUsers, UnitOfWork.UserRepository);
            var currentFarms = await UnitOfWork.FarmRepository.GetAllAsync();
            Utils.DeleteAll<FarmDto>(currentFarms, UnitOfWork.FarmRepository);
            var currentFarmFeilds = await UnitOfWork.FarmFeildRepository.GetAllAsync();
            Utils.DeleteAll<FarmFieldDto>(currentFarmFeilds, UnitOfWork.FarmFeildRepository);
            var currentSensors = await UnitOfWork.SensorRepository.GetAllAsync();
            Utils.DeleteAll<SensorDto>(currentSensors, UnitOfWork.SensorRepository);
        }
    }
}