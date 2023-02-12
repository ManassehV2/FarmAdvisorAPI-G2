
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FarmAdvisor.DataAccess.MSSQL.Implementations
{
    public class SensorRepositoryImpl : GenericRepositoryImpl<SensorDto>, ISensorRepository
    {
        public FarmAdvisorDbContext _context;
        public SensorRepositoryImpl(FarmAdvisorDbContext context) : base(context)
        {
            _context = context;
        }

        public async ValueTask<IEnumerable<SensorDto>> GetSensorByFieldId(Guid fieldId)
        {
            try{
                var sensors = _context.Sensors.Where(f => f.FeildId == fieldId).ToList();
                return sensors;
            }catch(Exception ex){
                throw ex;
            }
            
        }
    }
}