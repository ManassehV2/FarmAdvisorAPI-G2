using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class SensorResetDateDto
    {
        
        public Guid SensorId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
