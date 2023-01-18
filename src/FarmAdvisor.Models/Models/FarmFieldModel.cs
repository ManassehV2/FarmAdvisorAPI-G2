namespace FarmAdvisor.Models.Models
{
    public class FarmFieldModel
    {
        public Guid FieldId { get; set; }
        public string? Name { get; set; }
        public decimal Altitude { get; set; }
        public string? Polygon { get; set; }

    }
}