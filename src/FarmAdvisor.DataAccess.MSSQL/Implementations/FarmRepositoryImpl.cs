
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace  FarmAdvisor.DataAccess.MSSQL.Implementations
{
     public   class   FarmRepositoryImpl  : GenericRepositoryImpl<FarmDto>, IFarmRepository
    {
         public   FarmRepositoryImpl (FarmAdvisorDbContext context) :  base (context)
        {
        }
    }
}