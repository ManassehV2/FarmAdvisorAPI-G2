using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class UserDto
    {
        public UserDto(string phone)
        {
            UserId = new Guid();
            Phone = phone;
        }

        [Key]
        public Guid UserId { get; set; }
        public string Phone { get; set; }

        // Navigation properties
        public FarmDto? Farm { get; set; }
        

    }
}