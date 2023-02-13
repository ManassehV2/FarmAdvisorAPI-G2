using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class FarmFieldDto
    {

        public FarmFieldDto( string name, Double altitude, Guid farmId)
        {
            FieldId = Guid.NewGuid();
            Name = name;
            Altitude = altitude;
            FarmId = farmId;
        }
        
        [Key]
        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public Double Altitude { get; set; }
        public int GDDGoal { get; set; }
        public int CuttingDateEstimated { get; set; }
        public int CurrentGDD { get; set; }
        public DateTime LastSensorResetDate { get; set; }

        // Navigation properties
        [ForeignKey("FarmDto")]
        public Guid FarmId { get; set; }
        public FarmDto? Farm { get; set; }
        public List<SensorDto>? Sensors { get; set; }

    }
}