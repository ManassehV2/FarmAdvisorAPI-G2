
using FarmAdvisor.DataAccess.MSSQL.Abstractions;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Implementations
{
    public class UserRepositoryImpl : GenericRepositoryImpl<UserDto>, IUserRepository
    {
        public UserRepositoryImpl(FarmAdvisorDbContext context) : base(context)
        {
        }
    }
}