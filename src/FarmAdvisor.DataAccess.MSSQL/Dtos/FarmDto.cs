using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class FarmDto
    {
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
        
    }
    
}