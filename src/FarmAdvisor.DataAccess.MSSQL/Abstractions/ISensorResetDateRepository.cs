
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Abstractions

{
    public interface ISensorResetDateRepository : IGenericRepository<SensorResetDateDto>
    {
        ValueTask<IEnumerable<SensorResetDateDto>> GetSensorResetDateById(Guid SensorId);
        
    }
}