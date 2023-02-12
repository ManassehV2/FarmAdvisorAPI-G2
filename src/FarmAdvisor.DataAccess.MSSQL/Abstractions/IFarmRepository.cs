
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Abstractions

 { 
     public   interface   IFarmRepository : IGenericRepository<FarmDto>
     { 
        ValueTask<FarmDto> GetFarmByUserId(Guid userId);
     } 
 }