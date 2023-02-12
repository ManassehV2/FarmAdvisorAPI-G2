// using FarmAdvisor.Business;
// using FarmAdvisor.Models.Models;

// namespace FarmAdvisor.AppFunctions
// {
//     public class CreateUser
//     {
//         private readonly UserService _userService;
//         public CreateUser(UserService userService)
//         {
//             _userService = userService;
//         }
//         public async ValueTask<User> Execute(User user)
//         {
//             try
//             {
//                 return await _userService.CreateUser(user);
//             }
//             catch (Exception e)
//             {
//                 throw e;
//             }
//         }
//     }
// }