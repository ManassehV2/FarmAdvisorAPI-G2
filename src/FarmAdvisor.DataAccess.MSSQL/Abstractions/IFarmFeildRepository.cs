
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Abstractions

{
    public interface IFarmFeildRepository : IGenericRepository<FarmFieldDto>
    {
        ValueTask<IEnumerable<FarmFieldDto>> GetFarmFieldsByFarmId(Guid farmId);
        
    }
    
}