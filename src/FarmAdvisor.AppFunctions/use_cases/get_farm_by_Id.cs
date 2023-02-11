using FarmAdvisor.Business;
using FarmAdvisor.Models.Models;

namespace FarmAdvisor.AppFunctions{
    public class GetFarm{
        private readonly FarmService _farmService;
        public GetFarm(FarmService farmService){
            _farmService = farmService;
        }
        public async ValueTask<Farm> Execute(Guid farmId){
            try{
                return await _farmService.GetFarm(farmId);
            }catch(Exception e){
                throw e;
            }
        }
    }
}