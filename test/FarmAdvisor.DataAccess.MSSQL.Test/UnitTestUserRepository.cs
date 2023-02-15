using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;


namespace FarmAdvisor.DataAccess.MSSQL.Test
{
    public class UnitTestUserRepository
    {

        private readonly IUnitOfWork UnitOfWork;
        public UnitTestUserRepository()
        {
            UnitOfWork = UnitOfWorkGenerator.Generate();
        }


        [Fact]
        public async void AddUser_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("123456789");
            await UnitOfWork.UserRepository.AddAsync(user);
            var result = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
            UnitOfWork.DisposeContext();
            Assert.Equal(user, result);
            
        }

        [Fact]
        public async void GetUserBuId_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("123456789");
            await UnitOfWork.UserRepository.AddAsync(user);
            var result = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);

            Utils.DeleteAll<UserDto>(new List<UserDto> { user }, UnitOfWork.UserRepository);
            UnitOfWork.DisposeContext();

            Assert.Equal(user, result);
        }




        [Fact]
        public async void UpdateUser_Success_Test()
        {

            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("123456789");
            await UnitOfWork.UserRepository.AddAsync(user);
            user.Phone = "987654321";
            await UnitOfWork.UserRepository.UpdateAsync(user);
            var result = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
            Utils.DeleteAll<UserDto>(new List<UserDto> { user }, UnitOfWork.UserRepository);
            UnitOfWork.DisposeContext();
            Assert.Equal(user, result);
              
        }


        [Fact]
        public async void DeleteUser_Success_Test()
        {
            Utils.clearDatabase(UnitOfWork);
            var user = new UserDto("123456789");
            await UnitOfWork.UserRepository.AddAsync(user);
            var resultBeforeDelete = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
            await UnitOfWork.UserRepository.DeleteAsync(user);
            var resultAfterDelete = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
            UnitOfWork.DisposeContext();
            Assert.NotNull(resultBeforeDelete);
            Assert.Null(resultAfterDelete);
            
        }
        
    }
}