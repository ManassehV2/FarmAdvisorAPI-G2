
using FarmAdvisor.DataAccess.MSSQL;
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace  FarmAdvisor.DataAccess.MSSQL.Implementations
{
     public   class   SensorResetDateRepositoryImpl  : GenericRepositoryImpl<SensorResetDateDto>, ISensorResetDateRepository
    {
        public FarmAdvisorDbContext _context;

        public SensorResetDateRepositoryImpl (FarmAdvisorDbContext context) :  base (context)
        {
            _context = context;
        }

        public async ValueTask<IEnumerable<SensorResetDateDto>> GetSensorResetDateById(Guid sensorId)
        {
            try
            {
                var resetDates = _context.SensorResetDates.Where(d => d.SensorId == sensorId).ToList();
                return resetDates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}




// get farmField by farmId

