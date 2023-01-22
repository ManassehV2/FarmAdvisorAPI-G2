using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class UserDto
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? AuthId { get; set; }
        public string Password { get; set; }

        // Navigation properties
        public FarmDto? Farm { get; set; }
        

    }
}