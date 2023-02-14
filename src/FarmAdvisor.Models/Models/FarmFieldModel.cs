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
        public int GDDGoal { get; set; } = 400;
        public int CuttingDateEstimated { get; set; } = 10;
        public int CurrentGDD { get; set; } = 0;
        public DateTime LastSensorResetDate { get; set; } = DateTime.Now;

        // Navigation properties
        public Guid FarmId { get; set; }

    }
}