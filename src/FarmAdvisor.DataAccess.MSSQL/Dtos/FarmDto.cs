using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class FarmDto
    {
       

        public FarmDto( string? name, double latitudeNum, double longitudeNum )
        {
            FarmId = Guid.NewGuid();
            Name = name;
            LatitudeNum = latitudeNum;
            LongitudeNum = longitudeNum;
    
        }

        [Key]
        public Guid FarmId { get; set; }
        public string Name { get; set; }
        public double LatitudeNum { get; set; }
        public double LongitudeNum { get; set; }
        // Navigation properties
         public List<FarmFieldDto>? FarmFeilds { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
         public UserDto? User { get; set; }
         public List<NotificationDto>? Notifications { get; set; }
        
    }
    
}