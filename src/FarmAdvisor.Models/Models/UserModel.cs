namespace FarmAdvisor.Models.Models
{
    public class User
    {

        public User(Guid userId, string name, string email, string password, string? token)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            Token = token;
        }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }

    }
}