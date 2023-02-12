namespace FarmAdvisor.Models.Models
{
    public class FarmFieldModel
    {
        
        public FarmFieldModel(Guid? fieldId, string name, decimal altitude, Guid farmId)
        {
            FieldId = fieldId;
            Name = name;
            Altitude = altitude;
            FarmId = farmId;
        }
        public Guid? FieldId { get; set; }
        public string? Name { get; set; }
        public decimal Altitude { get; set; }
        public Guid FarmId { get; set; }

    }
}