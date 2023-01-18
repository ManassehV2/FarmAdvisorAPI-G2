
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL.Abstractions
{
    public interface IUserRepository : IGenericRepository<UserDto>
    {
    }
}
       