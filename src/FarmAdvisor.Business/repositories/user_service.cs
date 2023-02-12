using FarmAdvisor.Models.Models;
using FarmAdvisor.DataAccess.MSSQL.Dtos;
using FarmAdvisor.DataAccess.MSSQL.Abstractions;

namespace FarmAdvisor.Business
{
    public class UserService
    {
      
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<User> CreateUser(User user)
        {
            try{
                var userDto = new UserDto( user.Name, user.Email, user.Password);
                var newUser = await _unitOfWork.UserRepository.AddAsync(userDto);
                _unitOfWork.SaveChanges();
                return new User(newUser.UserId, newUser.Name, newUser.Email, newUser.Password, newUser.AuthId);
            }catch(Exception e){
                throw e;
            }
            
        }

        public async ValueTask<User> GetUser(Guid userId)
        {
            try{
                var userDto =  await _unitOfWork.UserRepository.GetByIdAsync(userId);
                return new User(userDto.UserId, userDto.Name, userDto.Email, userDto.Password, userDto.AuthId);
            }
            catch(Exception e){
                throw e;
            }
        }

        //delete user
        public async ValueTask<User> DeleteUser(Guid userId)
        {
            try{
                var userDto = await _unitOfWork.UserRepository.GetByIdAsync(userId);
                var user = new User(userDto.UserId, userDto.Name, userDto.Email, userDto.Password, userDto.AuthId);
                _unitOfWork.UserRepository.DeleteAsync(userDto);
                _unitOfWork.SaveChanges();
                return user;
            }
            catch(Exception e){
                throw e;
            }
        }

        // get all users
        public async ValueTask<IEnumerable<User>> GetAllUsers()
        {
            try{
                var userDtos = await _unitOfWork.UserRepository.GetAllAsync();
                var users = userDtos.Select(userDto => new User(userDto.UserId, userDto.Name, userDto.Email, userDto.Password, userDto.AuthId));
                return users;
            }
            catch(Exception e){
                throw e;
            }
        }


    }
}