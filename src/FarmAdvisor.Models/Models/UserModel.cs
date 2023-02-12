namespace FarmAdvisor.Models.Models
{
    public class User
    {
        


        public User(Guid? userId, string Phone)
        {
            UserId = userId;
            this.Phone = Phone;
            
        }
        
        public Guid? UserId { get; set; }
        public string Phone { get; set; }

        public Farm? Farm { get; set; }

    }
}