using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class SensorResetDateDto
    {
        [Key]
        public Guid SRDId { get; set; }
        public DateTime Timestamp { get; set; }

        [ForeignKey("Sensor")]
        public Guid SensorId { get; set; }
        public SensorDto? Sensor { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public UserDto? User { get; set; }
        
    }
}
