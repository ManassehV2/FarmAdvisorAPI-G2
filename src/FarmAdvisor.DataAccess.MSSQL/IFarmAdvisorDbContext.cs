using Microsoft.EntityFrameworkCore;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL
{
    public interface IFarmAdvisorDbContext
    {
        DbSet<FarmDto> Farms { get; set; }
        DbSet<FarmFieldDto> FarmFeilds { get; set; }
        DbSet<SensorDto> Sensors { get; set; }
        DbSet<UserDto> Users { get; set; }
        DbSet<NotificationDto> Notifications { get; set; }
        DbSet<SensorResetDateDto> SensorResetDates { get; set; }
        
    }
       
}
