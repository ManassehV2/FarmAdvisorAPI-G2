// using FarmAdvisor.Business;
// using FarmAdvisor.Models.Models;

// namespace FarmAdvisor.AppFunctions
// {
//     public class DeleteFarm
//     {
//         private readonly FarmService _farmService;
//         public DeleteFarm(FarmService farmService)
//         {
//             _farmService = farmService;
//         }
//         public async ValueTask<Farm> Execute(Guid farmId)
//         {
//             try
//             {
//                 return await _farmService.DeleteFarm(farmId);
//             }
//             catch (Exception e)
//             {
//                 throw e;
//             }
//         }
//     }
// }