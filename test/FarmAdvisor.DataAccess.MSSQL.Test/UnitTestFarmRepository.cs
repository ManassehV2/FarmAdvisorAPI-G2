using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;


namespace FarmAdvisor.DataAccess.MSSQL.Test
{
    public class UnitTestFarmRepository
    {

        private readonly IUnitOfWork UnitOfWork;
        public UnitTestFarmRepository()
        {
            UnitOfWork = UnitOfWorkGenerator.Generate();
        }


        [Fact]
        public async void AddFarm_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("123456789");
            await UnitOfWork.UserRepository.AddAsync(user);
            var userCreated = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
            var farm = new FarmDto("Farm1", 24, 8);
            await UnitOfWork.FarmRepository.AddAsync(farm);
            var result = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.DisposeContext();

            Assert.Equal(farm, result);
            
        }

        [Fact]
        public async void GetFarmById_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("123456789");
            await UnitOfWork.UserRepository.AddAsync(user);
            var createdUser = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
            var farm = new FarmDto("Farm1", 24, 8);
            await UnitOfWork.FarmRepository.AddAsync(farm);
            var result = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.DisposeContext();
            Assert.Equal(farm, result);
        }


       


    


        [Fact]
        public async void DeleteFarm_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var farm = new FarmDto("Farm1", 24, 8);
            await UnitOfWork.FarmRepository.AddAsync(farm);
            var resultBeforeDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            await UnitOfWork.FarmRepository.DeleteAsync(farm);
            var resultAfterDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.UserId);

            UnitOfWork.DisposeContext();

            Assert.NotNull(resultBeforeDelete);
            Assert.Null(resultAfterDelete);
            
        }

    }}