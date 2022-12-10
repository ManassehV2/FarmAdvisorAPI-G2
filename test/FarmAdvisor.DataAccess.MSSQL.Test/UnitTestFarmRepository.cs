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
            var farm = DtoGenerator.GenerateFarmDto();
            await UnitOfWork.FarmRepository.AddAsync(farm);
            var result = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.Dispose();

            Assert.Equal(farm, result);
            
        }

        [Fact]
        public async void GetFarmById_Success_Test()
        {
            var farm = DtoGenerator.GenerateFarmDto();
            await UnitOfWork.FarmRepository.AddAsync(farm);
            var result = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.Dispose();
            Assert.Equal(farm, result);
        }


        [Fact]
        public async void GetAllFarms_Success_Test()
        {
            // clean database
            var currentFarms = await UnitOfWork.FarmRepository.GetAllAsync();

            if (currentFarms.Count > 0)
            {
                Utils.DeleteAll<FarmDto>(currentFarms, UnitOfWork.FarmRepository);
            }
            

            // populate database
            int numberOfFarms = 10;

            
            foreach(int i in Enumerable.Range(0, numberOfFarms))
            {
                var farm = DtoGenerator.GenerateFarmDto();
                await UnitOfWork.FarmRepository.AddAsync(farm);
            }
            
          

            // test GetAll
            var result = await UnitOfWork.FarmRepository.GetAllAsync();

            // clean database
            Utils.DeleteAll<FarmDto>(result, UnitOfWork.FarmRepository);
            UnitOfWork.Dispose();

            // test
            Assert.Equal(numberOfFarms, result.Count);
            
        }


        [Fact]
        public async void UpdateFarm_Success_Test()
        {

            var farm = DtoGenerator.GenerateFarmDto();
            await UnitOfWork.FarmRepository.AddAsync(farm);
            farm.Name = "Updated Name";
            await UnitOfWork.FarmRepository.UpdateAsync(farm);
            var result = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);

            UnitOfWork.Dispose();
            Assert.Equal(farm, result);
              
        }


        [Fact]
        public async void DeleteFarm_Success_Test()
        {
            var farm = DtoGenerator.GenerateFarmDto();
            await UnitOfWork.FarmRepository.AddAsync(farm);
            var resultBeforeDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            await UnitOfWork.FarmRepository.DeleteAsync(farm);
            var resultAfterDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.UserId);

            UnitOfWork.Dispose();

            Assert.NotNull(resultBeforeDelete);
            Assert.Null(resultAfterDelete);
            
        }

        [Fact]
        public async void Relation_Success_Test()
        {
            var user = DtoGenerator.GenerateUserDto();
            var farm = DtoGenerator.GenerateFarmDto();
            var farmField = DtoGenerator.GenerateFarmFieldDto();

            user.Farm = farm;
            farm.FarmFeilds!.Add(farmField);
            farmField.Farm = farm;
            farmField.FarmId = farm.FarmId;

            await UnitOfWork.UserRepository.AddAsync(user);
            
            
            var userResult = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
            var farmResult = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            var farmFieldResult = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmField.FieldId);
            Utils.DeleteAll<UserDto>(new List<UserDto> { user }, UnitOfWork.UserRepository);
            UnitOfWork.Dispose();

            Assert.Equal(user.Farm, userResult!.Farm);
            Assert.Equal(farm.User, farmResult!.User);
            Assert.Equal(user.UserId, farmResult.UserId);
            Assert.NotNull(farmFieldResult);
            Assert.Equal(farmFieldResult.FarmId, farmResult.FarmId);


        }

        

        
    }
}