using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmAdvisor.DataAccess.MSSQL.Dtos;

namespace FarmAdvisor.DataAccess.MSSQL
{
    public class FarmAdvisorDbContext : DbContext, IFarmAdvisorDbContext
    {
    
       

        public FarmAdvisorDbContext(DbContextOptions<FarmAdvisorDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<FarmDto> Farms { get; set; }
        public DbSet<FarmFieldDto> FarmFeilds { get; set; }
        public DbSet<SensorDto> Sensors { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<NotificationDto> Notifications { get; set; }

    }
    
}
