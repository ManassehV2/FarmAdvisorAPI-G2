namespace FarmAdvisor.Models.Models
{
    public class Farm
    {
        public Farm(Guid? farmId, string name, double latitude, double longitude, Guid userId){
            FarmId = (Guid)(farmId != null ? farmId : Guid.NewGuid());
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            UserId = userId;
        }
        
        public Guid FarmId { get; set; }
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid UserId { get; set; }
        public List<FarmFieldModel>? FarmFeilds { get; set; }
    }
}