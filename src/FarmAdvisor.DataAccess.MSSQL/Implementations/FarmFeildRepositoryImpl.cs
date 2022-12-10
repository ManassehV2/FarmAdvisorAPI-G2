
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Implementations
{
    public class FarmFeildRepositoryImpl : GenericRepositoryImpl<FarmFieldDto>, IFarmFeildRepository
    {
        public FarmFeildRepositoryImpl(FarmAdvisorDbContext context) : base(context)
        {
        }
    }
}