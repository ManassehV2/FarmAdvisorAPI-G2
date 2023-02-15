using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;



namespace FarmAdvisor.DataAccess.MSSQL.Test
{
    public class UnitTestFarmFeildRepository
    {

        private readonly IUnitOfWork UnitOfWork;
        public UnitTestFarmFeildRepository()
        {
            UnitOfWork = UnitOfWorkGenerator.Generate();
        }

        

        [Fact]
        public async void AddFarmFeild_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var farm = new FarmDto( "09232323223", 24, 8);
            var farmFeild = new FarmFieldDto( "field1", 2399, farm.FarmId);
            await UnitOfWork.FarmFeildRepository.AddAsync(farmFeild);
            var result = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);
            UnitOfWork.DisposeContext();

            Assert.NotNull(result);
            


        }

        [Fact]
        public async void GetFarmFeildById_Success_Test()
        {

            Utils.clearDatabase(UnitOfWork);
            var farm = new FarmDto( "09232323223", 24, 8);
            var farmFeild = new FarmFieldDto( "field1", 2399, farm.FarmId);
            await UnitOfWork.FarmFeildRepository.AddAsync(farmFeild);
            var result = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);
            UnitOfWork.DisposeContext();
            
            Assert.Equal(farmFeild, result);
        }


       



        [Fact]
        public async void DeleteFarmFeild_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            
            var farm = new FarmDto( "09232323223", 24, 8);
            var farmFeild = new FarmFieldDto( "field1", 2399, farm.FarmId);
            await UnitOfWork.FarmRepository.AddAsync(farm);
            await UnitOfWork.FarmFeildRepository.DeleteAsync(farmFeild);
            var resultAfterDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.UserId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.DisposeContext();
            Assert.Null(resultAfterDelete);
            
            
        }


        
    }
}