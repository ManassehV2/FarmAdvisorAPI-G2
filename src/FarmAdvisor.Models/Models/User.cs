namespace FarmAdvisor.Models.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AuthId { get; set; }

        public Guid FarmId { get; set; }
        public Farm Farm { get; set; }

    }
}