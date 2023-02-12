// using FarmAdvisor.Models.Models;

// namespace FarmAdvisor.Business{
//     public class CreateFarm{

//         private readonly FarmService _farmService;
//         public CreateFarm( FarmService farmService){
//             _farmService = farmService;
//         }

//         public async ValueTask<Farm> Execute(Farm farm){
//             try{
//                 _farmService.AddFarm(farm);
//                 return await _farmService.GetFarm(farm.FarmId);
//             }catch(Exception e){
//                 throw e;
//             }
//         }
            
//     }
// }
