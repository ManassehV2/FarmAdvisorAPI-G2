
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace  FarmAdvisor.DataAccess.MSSQL.Implementations
{
     public   class   SensorResetDateRepositoryImpl  : GenericRepositoryImpl<SensorResetDateDto>, ISensorResetDateRepository
    {
         public   SensorResetDateRepositoryImpl (FarmAdvisorDbContext context) :  base (context)
        {

        }
    }
}