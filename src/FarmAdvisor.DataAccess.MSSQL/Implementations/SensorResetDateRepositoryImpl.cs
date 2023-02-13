
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace  FarmAdvisor.DataAccess.MSSQL.Implementations
{
     public   class   SensorResetDateRepositoryImpl  : GenericRepositoryImpl<SensorResetDateDto>, ISensorResetDateRepository
    {
        private readonly FarmAdvisorDbContext _context;
         public   SensorResetDateRepositoryImpl (FarmAdvisorDbContext context) :  base (context)
        {
            _context = context;
        }

        public async ValueTask<SensorResetDateDto> GetSensorResetDateBySensorId(Guid id)
        {
            return await _context.SensorResetDates.FindAsync(id);
        }
    }
}