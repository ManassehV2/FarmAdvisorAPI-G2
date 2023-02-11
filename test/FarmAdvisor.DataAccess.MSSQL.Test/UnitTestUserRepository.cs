// using FarmAdvisor.DataAccess.MSSQL.Abstractions;
// using FarmAdvisor.DataAccess.MSSQL.Dtos;


// namespace FarmAdvisor.DataAccess.MSSQL.Test
// {
//     public class UnitTestUserRepository
//     {

//         private readonly IUnitOfWork UnitOfWork;
//         public UnitTestUserRepository()
//         {
//             UnitOfWork = UnitOfWorkGenerator.Generate();
//         }


//         [Fact]
//         public async void AddUser_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);
//             var user = DtoGenerator.GenerateUserDto();
//             await UnitOfWork.UserRepository.AddAsync(user);
//             var result = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
//             Utils.DeleteAll<UserDto>(new List<UserDto> { user }, UnitOfWork.UserRepository);
//             UnitOfWork.DisposeContext();
//             Assert.Equal(user, result);
            
//         }

//         [Fact]
//         public async void GetUserBuId_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);
//             var user = DtoGenerator.GenerateUserDto();
//             await UnitOfWork.UserRepository.AddAsync(user);
//             var result = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);

//             Utils.DeleteAll<UserDto>(new List<UserDto> { user }, UnitOfWork.UserRepository);
//             UnitOfWork.DisposeContext();

//             Assert.Equal(user, result);
//         }


//         [Fact]
//         public async void GetAllUsers_Success_Test()
//         {
//             // clean database
//             Utils.clearDatabase(UnitOfWork);
//             var currentUsers = await UnitOfWork.UserRepository.GetAllAsync();
//             Utils.DeleteAll<UserDto>(currentUsers, UnitOfWork.UserRepository);

//             // populate database
//             int numberOfUsers = 10;
//             var users = DtoGenerator.GenerateUserDtos(numberOfUsers);
//             users.ForEach(async user => await UnitOfWork.UserRepository.AddAsync(user));
//             // test GetAll
//             var result = await UnitOfWork.UserRepository.GetAllAsync();

//             // clean database
//             Utils.DeleteAll<UserDto>(users, UnitOfWork.UserRepository);
//             UnitOfWork.DisposeContext();
//             Assert.Equal(numberOfUsers , result.Count);
            
//         }


//         [Fact]
//         public async void UpdateUser_Success_Test()
//         {

//             Utils.clearDatabase(UnitOfWork);
//             var user = DtoGenerator.GenerateUserDto();
//             await UnitOfWork.UserRepository.AddAsync(user);
//             user.Name = "Updated Name";
//             await UnitOfWork.UserRepository.UpdateAsync(user);
//             var result = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
//             Utils.DeleteAll<UserDto>(new List<UserDto> { user }, UnitOfWork.UserRepository);
//             UnitOfWork.DisposeContext();
//             Assert.Equal(user, result);
              
//         }


//         [Fact]
//         public async void DeleteUser_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);
//             var user = DtoGenerator.GenerateUserDto();
//             await UnitOfWork.UserRepository.AddAsync(user);
//             var resultBeforeDelete = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
//             await UnitOfWork.UserRepository.DeleteAsync(user);
//             var resultAfterDelete = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);

//             UnitOfWork.DisposeContext();

//             Assert.NotNull(resultBeforeDelete);
//             Assert.Null(resultAfterDelete);
            
//         }

//         [Fact]
//         public async void Relation_Success_Test()
//         {
//             Utils.clearDatabase(UnitOfWork);
//             var user = DtoGenerator.GenerateUserDto();
//             var farm = DtoGenerator.GenerateFarmDto();

//             user.Farm = farm;
            

//             await UnitOfWork.FarmRepository.AddAsync(farm);
//             await UnitOfWork.UserRepository.AddAsync(user);
            

//             var userResult = await UnitOfWork.UserRepository.GetByIdAsync(user.UserId);
//             var farmResult = await UnitOfWork.FarmRepository.GetByIdAsync(farm.FarmId);

//             Utils.DeleteAll<UserDto>(new List<UserDto> { user }, UnitOfWork.UserRepository);
//             UnitOfWork.DisposeContext();

//             Assert.Equal(user.Farm, userResult!.Farm);
//             Assert.Equal(farm.User, farmResult!.User);
//             Assert.Equal(user.UserId, farmResult.UserId);


//         }

        

        
//     }
// }