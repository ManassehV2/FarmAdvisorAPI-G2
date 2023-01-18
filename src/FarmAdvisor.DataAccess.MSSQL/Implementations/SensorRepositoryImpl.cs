
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Implementations
{
    public class SensorRepositoryImpl : GenericRepositoryImpl<SensorDto>, ISensorRepository
    {
        public SensorRepositoryImpl(FarmAdvisorDbContext context) : base(context)
        {
        }
    }
}