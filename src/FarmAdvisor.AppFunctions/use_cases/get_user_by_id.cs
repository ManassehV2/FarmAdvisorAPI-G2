using FarmAdvisor.Business;
using FarmAdvisor.Models.Models;

namespace FarmAdvisor.AppFunctions
{
    public class GetUserById
    {
        private readonly UserService _userService;
        public GetUserById(UserService userService)
        {
            _userService = userService;
        }
        public async ValueTask<User> Execute(Guid userId)
        {
            try
            {
                return await _userService.GetUser(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}