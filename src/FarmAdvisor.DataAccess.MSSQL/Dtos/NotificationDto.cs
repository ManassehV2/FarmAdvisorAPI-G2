using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public enum Status
    {
        OK,
        WARNING

    }
    public class NotificationDto
    {

        [Key]
        public Guid NotificationId { get; set; }

        [ForeignKey("FarmDto")]
        public Guid FarmId { get; set; }
        public FarmDto? Farm { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Status Status { get; set; }
        
    }
}
