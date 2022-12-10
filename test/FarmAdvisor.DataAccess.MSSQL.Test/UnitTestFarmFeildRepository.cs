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
            var farm = DtoGenerator.GenerateFarmDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();

            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            var farmResult = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            var farmFeildResult = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);

            UnitOfWork.Dispose();

            Assert.NotNull(farmResult);
            Assert.NotNull(farmFeildResult);
            Assert.Single(farmResult.FarmFeilds!);
            Assert.Equal(farmFeildResult, farmResult.FarmFeilds![0]);


        }

        [Fact]
        public async void GetFarmFeildById_Success_Test()
        {

            Utils.clearDatabase(UnitOfWork);
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            await UnitOfWork.FarmFeildRepository.AddAsync(farmFeild);
            var result = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);
            UnitOfWork.Dispose();
            
            Assert.Equal(farmFeild, result);
        }


        [Fact]
        public async void GetAllFarmFeilds_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);


            // populate database
            int numberOfFarmFeilds = 10;

            var farm = DtoGenerator.GenerateFarmDto();
            foreach(int i in Enumerable.Range(0, numberOfFarmFeilds))
            {
                var farmFeild = DtoGenerator.GenerateFarmFieldDto();
                farm.FarmFeilds!.Add(farmFeild);
                
            }
            await UnitOfWork.FarmRepository.AddAsync(farm);

            // test GetAll
            var result = await UnitOfWork.FarmFeildRepository.GetAllAsync();

            // clean database
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            var feildsAfterDelete = await UnitOfWork.FarmFeildRepository.GetAllAsync();
            UnitOfWork.Dispose();
            Assert.Empty(feildsAfterDelete);
            Assert.Equal(numberOfFarmFeilds, result.Count);
            
        }


        [Fact]
        public async void UpdateFarmFeild_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var farm = DtoGenerator.GenerateFarmDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            farmFeild.Farm = farm;
            farmFeild.FarmId = farm.FarmId;

            
            await UnitOfWork.FarmFeildRepository.UpdateAsync(farmFeild);
            var resultAfterUpdate = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);

            UnitOfWork.Dispose();
            Assert.Equal(farmFeild, resultAfterUpdate);
              
        }


        [Fact]
        public async void DeleteFarmFeild_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var farm = DtoGenerator.GenerateFarmDto();
            var farmFeild = DtoGenerator.GenerateFarmFieldDto();
            farm.FarmFeilds!.Add(farmFeild);
            await UnitOfWork.FarmRepository.AddAsync(farm);

            farmFeild.Farm = farm;

            var resultBeforeDelete = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmFeild.FieldId);
            await UnitOfWork.FarmFeildRepository.DeleteAsync(resultBeforeDelete!);
            var resultAfterDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.UserId);
            var farmAfterDelete = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            Utils.DeleteAll<FarmDto>(new List<FarmDto> { farm }, UnitOfWork.FarmRepository);
            UnitOfWork.Dispose();

            Assert.NotNull(resultBeforeDelete);
            Assert.Null(resultAfterDelete);
            Assert.Empty(farmAfterDelete!.FarmFeilds!);
            
        }

        [Fact]
        public async void Relation_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var farm = DtoGenerator.GenerateFarmDto();
            var farmField = DtoGenerator.GenerateFarmFieldDto();

            
            farm.FarmFeilds!.Add(farmField);
            await UnitOfWork.FarmRepository.AddAsync(farm);
            

            var farmResult = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);
            var farmFieldResult = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmField.FieldId);

            Assert.Equal(farm.User, farmResult!.User);
            Assert.NotNull(farmFieldResult);
            Assert.Equal(farmField.Farm, farmFieldResult!.Farm);

            await UnitOfWork.FarmRepository.DeleteAsync(farmResult);
            var farmFieldResultAfterDelete = await UnitOfWork.FarmFeildRepository.GetByIdAsync(farmField.FieldId);
            UnitOfWork.Dispose();

            Assert.Null(farmFieldResultAfterDelete);


        }

        

        
    }
}