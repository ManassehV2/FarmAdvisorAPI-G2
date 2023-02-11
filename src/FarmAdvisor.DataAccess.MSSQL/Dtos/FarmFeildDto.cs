using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class FarmFieldDto
    {

        public FarmFieldDto( string name, Double altitude, string? polygon, Guid farmId)
        {
            FieldId = Guid.NewGuid();
            Name = name;
            Altitude = altitude;
            Polygon = polygon;
            FarmId = farmId;
        }
        
        [Key]
        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public Double Altitude { get; set; }
        public string? Polygon { get; set; }

        // Navigation properties
        [ForeignKey("FarmDto")]
        public Guid FarmId { get; set; }
        public FarmDto Farm { get; set; }

        public List<SensorDto>? Sensors { get; set; }

    }
}