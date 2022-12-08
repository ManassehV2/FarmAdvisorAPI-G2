using System.ComponentModel.DataAnnotations;

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

         public List<FarmFieldDto>? FarmFeilds { get; set; }
         public Guid UserId { get; set; }
        
    }
    
}