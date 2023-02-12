// using FarmAdvisor.Business;
// using FarmAdvisor.Models.Models;

// namespace FarmAdvisor.AppFunctions
// {
//     public class CreateFarmField
//     {
//         private readonly FarmFieldService _farmFieldService;
//         public CreateFarmField(FarmFieldService farmFieldService)
//         {
//             _farmFieldService = farmFieldService;
//         }
//         public async ValueTask<FarmFieldModel> Execute(FarmFieldModel farmField)
//         {
//             try
//             {
//                 return await _farmFieldService.CreateFarmField(farmField);
//             }
//             catch (Exception e)
//             {
//                 throw e;
//             }
//         }
//     }
// }