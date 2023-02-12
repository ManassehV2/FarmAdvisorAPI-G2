// using FarmAdvisor.Business;
// using FarmAdvisor.Models.Models;

// namespace FarmAdvisor.AppFunctions
// {
//     public class DeleteUser{
//         private readonly UserService _userService;
//         public DeleteUser(UserService userService){
//             _userService = userService;
//         }
//         public async ValueTask<User> Execute(Guid userId){
//             try{
//                 return await _userService.DeleteUser(userId);
//             }catch(Exception e){
//                 throw e;
//             }
//         }
//     }
// }