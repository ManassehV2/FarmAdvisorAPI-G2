namespace FarmAdvisor.Models.Models
{
    public class Farm
    {
         public Guid FarmId { get; set; }
        public string Name { get; set; }
        public string Postcode{ get; set; }
        public string City { get; set; }
        public string Country { get; set; }

       // public List<FarmFieldModel> FarmFeilds { get; set; }
       // public Guid UserId { get; set; }
        

    }
}