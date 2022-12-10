using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL
{
    public interface IFarmAdvisorDbContext
    {
        DbSet<FarmDto> Farms { get; set; }
        DbSet<FarmFieldDto> FarmFeilds { get; set; }
        DbSet<SensorDto> Sensors { get; set; }
        DbSet<UserDto> Users { get; set; }
    }
       
}
