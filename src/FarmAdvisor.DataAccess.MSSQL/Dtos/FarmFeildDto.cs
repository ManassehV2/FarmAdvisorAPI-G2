using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmAdvisor.DataAccess.MSSQL.Dtos
{
    public class FarmFieldDto
    {
        [Key]
        public Guid FieldId { get; set; }
        public string? Name { get; set; }
        public decimal Altitude { get; set; }
        public string? Polygon { get; set; }

        // Navigation properties
        [ForeignKey("FarmDto")]
        public Guid FarmId { get; set; }
        public FarmDto? Farm { get; set; }

        public List<SensorDto>? Sensors { get; set; }

    }
}