
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Abstractions
 { 
     public   interface   ISensorRepository : IGenericRepository<SensorDto>
     { 
        ValueTask<IEnumerable<SensorDto>> GetSensorByFieldId(Guid fieldId);
     } 
 }