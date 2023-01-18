using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public enum Status{
        READ,
        UNREAD
    }
    public class NotificationDto
    {
        [Key]
        public Guid NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Status Status { get; set; }
       
        [ForeignKey("FarmDto")]
        public Guid FarmId { get; set; }
        public FarmDto? Farm { get; set; }
        
    }
}