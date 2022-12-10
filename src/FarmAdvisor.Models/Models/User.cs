using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.Models.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AuthId { get; set; }

        [ForeignKey("FarmDto")]
        public Guid FarmId { get; set; }
        public Farm Farm { get; set; }

    }
}