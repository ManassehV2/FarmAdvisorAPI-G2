namespace FarmAdvisor.Models.Models
{
    public class FarmFieldModel
    {
        public FarmFieldModel() { }
        public FarmFieldModel(Guid fieldId, string name, decimal altitude, string polygon, Guid farmId)
        {
            FieldId = fieldId;
            Name = name;
            Altitude = altitude;
            Polygon = polygon;
            FarmId = farmId;
        }
        public Guid FieldId { get; set; }
        public string? Name { get; set; }
        public decimal Altitude { get; set; }
        public string? Polygon { get; set; }
        
        public Guid FarmId { get; set; }

    }
}