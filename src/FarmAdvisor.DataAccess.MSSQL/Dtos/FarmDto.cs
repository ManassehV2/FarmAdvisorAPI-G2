using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class FarmDto
    {

        public FarmDto(Guid farmId, string? name, Guid userId, string? postcode, string? city, string? country)
        {
            FarmId = farmId;
            Name = name;
            UserId = userId;
            Postcode = postcode;
            City = city;
            Country = country;
            
        }
        [Key]
        public Guid FarmId { get; set; }
        public string? Name { get; set; }
        public string? Postcode{ get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        // Navigation properties
         public List<FarmFieldDto>? FarmFeilds { get; set; }

         [ForeignKey("User")]
         public Guid UserId { get; set; }
         public UserDto? User { get; set; }
         public List<NotificationDto>? Notifications { get; set; }
        
    }
    
}