namespace FarmAdvisor.Models.Models
{
    public class Farm
    {
        
        public Farm(Guid farmId, string name, string postcode, string city, string country, Guid userId, List<FarmFieldModel>? farmFeilds)
        {
            FarmId = farmId;
            Name = name;
            Postcode = postcode;
            City = city;
            Country = country;
            UserId = userId;
            FarmFeilds = farmFeilds;
        }
        public Guid FarmId { get; set; }
        public string? Name { get; set; }
        public string? Postcode{ get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public Guid UserId { get; set; }
        public List<FarmFieldModel>? FarmFeilds { get; set; }
    }
}