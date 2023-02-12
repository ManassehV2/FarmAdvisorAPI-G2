// using FarmAdvisor.Business;
// using FarmAdvisor.Models.Models;

// namespace FarmAdvisor.AppFunctions{
//     public class GetFarmFieldById{
//         private readonly FarmFieldService _farmFieldService;
//         public GetFarmFieldById(FarmFieldService farmFieldService){
//             _farmFieldService = farmFieldService;
//         }
//         public async ValueTask<FarmFieldModel> Execute(Guid farmFieldId){
//             try{
//                 return await _farmFieldService.GetFarmField(farmFieldId);
//             }catch(Exception e){
//                 throw e;
//             }
//         }
//     }
// }