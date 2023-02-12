// using FarmAdvisor.Business;
// using FarmAdvisor.Models.Models;

// namespace FarmAdvisor.AppFunctions{
//     public class GetFieldsInFarm{
//         private readonly FarmService _farmService;

//         public GetFieldsInFarm(FarmService farmService){
//             _farmService = farmService;
//         }

//         public async ValueTask<IEnumerable<FarmFieldModel>> Execute(Guid farmId){
//             try{
//                 return await _farmService.GetFarmFields(farmId);
//             }catch(Exception e){
//                 throw e;
//             }
//         }
        
//     }
// }